using AutoMapper;
using ITI_ProjectFinal.DTOs;
using ITI_ProjectFinal.Models;
using ITI_ProjectFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ProjectFinal.Controllers
{
    public class StudentController : Controller
    {
        

        private readonly ITIContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;


        public StudentController(ITIContext _context, IWebHostEnvironment _webHostEnvironment, IMapper _mapper)
        {
            context = _context;
            webHostEnvironment = _webHostEnvironment;
            mapper = _mapper;
        }


        #region Index 

        [HttpGet]
        public IActionResult index()
        {
            return View("Index", context.Students.ToList());
        }
        #endregion

        #region Detials

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return BadRequest("Not Found");
            }

            Student stuDto = context.Students.FirstOrDefault(ins => ins.Id == id);

       
     return View("Details", stuDto);
        }
        #endregion

        #region Add
        [HttpGet]
        public IActionResult Add()
        {

            

             ViewData["Courses_list"] = context.Courses.ToList();
            return View("Add", new StudentDto());

        }
        #endregion

        #region SaveAdd

        [HttpPost]
        public IActionResult SaveAdd([FromForm] StudentDto studentDto)
        {
            if (ModelState.IsValid == false)
            {
                if (studentDto.ImageFile != null)
                {
                    string imgePath = "//upload//" + Guid.NewGuid() + studentDto.ImageFile.FileName;
                    string imgFullPath = webHostEnvironment.WebRootPath + imgePath;
                    FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
                    studentDto.ImageFile.CopyTo(fileStream);
                    fileStream.Dispose();

                    studentDto.ImageUrl = imgePath;

                }

               
                List<Course> course_listDB = context.Courses.ToList();

                

                Student stuAddDB = new Student
                {
                    Name = studentDto.Name,
                    Address = studentDto.Address,
                    Degree = studentDto.Degree,
                    ImageUrl = studentDto.ImageUrl // Set the image path
                };


                context.Students.Add(stuAddDB);
                studentDto.Course_list = course_listDB;
                

                context.SaveChanges();
                return RedirectToAction("Index");


            }
            else
            {
                ViewData["Courses_list"] = context.Courses.ToList();

                return View("AddNew", studentDto);
            }
        }
        #endregion

        #region Edit

        [HttpGet]
        public IActionResult Edit(int id)
        {
          
            Student? stu = context.Students.FirstOrDefault(c => c.Id == id);

            if (stu == null)
            {
                return NotFound();
            }
         
            StudentDto stuDto = new StudentDto
            {

                Name = stu.Name,
                Degree = stu.Degree,
                ImageUrl = stu.ImageUrl,

            };
            return View("Edit", stuDto);
        }

        #endregion

        #region SaveEdit
        [HttpPost]
        public IActionResult SaveEdit(StudentDto stuDto)
        {
            if (ModelState.IsValid == true)
            {

                if (stuDto.ImageFile != null)
                {

                    if (System.IO.File.Exists(webHostEnvironment.WebRootPath + stuDto.ImageUrl))
                    {
                        System.IO.File.Delete(webHostEnvironment.WebRootPath + stuDto.ImageUrl);
                    }

                    string imgePath = "//upload//" + Guid.NewGuid() + stuDto.ImageFile.FileName;
                    string imgFullPath = webHostEnvironment.WebRootPath + imgePath;
                    FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
                    stuDto.ImageFile.CopyTo(fileStream);
                    fileStream.Dispose();

                    stuDto.ImageUrl = imgePath;


                }
                var student = mapper.Map<Student>(stuDto);

              
                context.Students.Update(student);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
               ViewData["Course_list"] = context.Courses.ToList();

                return View("Edit");
            }
        }
        #endregion


    }
}
