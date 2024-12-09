using ITI_ProjectFinal.Models;
using ITI_ProjectFinal.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ITI_ProjectFinal.Controllers
{
    public class CourseController : Controller
    {

         private readonly ITIContext context;
         private readonly IWebHostEnvironment webHostEnvironment;
         private readonly IMapper mapper;
 

        public CourseController(ITIContext _context , IWebHostEnvironment _webHostEnvironment , IMapper _mapper)
        {
            context = _context;
            webHostEnvironment = _webHostEnvironment;
            mapper = _mapper;
        }







        #region Get

        [HttpGet]
        public IActionResult Get(string? search = "")
        {
            if (context == null)
            {
                return StatusCode(500, "Database context is null.");
            }

            try
            {
                List<Course> course;

                if (!string.IsNullOrEmpty(search))
                {

                    course = context.Courses
                        .Where(c => c.Name.Contains(search.Trim()) || c.Address.Contains(search.Trim()))
                        .ToList();
                }
                else
                {
                    
                    course = context.Courses.ToList();
                }

                ViewBag.CurrentSearch = search;
                return View("Index", course);
            }
            catch (Exception ex)
            {
               
                // Return a user-friendly error message
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        #endregion

        #region Add

        [HttpGet]
        public IActionResult Add()  
        {

            ViewData["Instructor_list"] = context.Instructors.ToList(); 
            return View("AddNew",new CourseDto()); // adding not Retive so use New (Entity)
        }
        #endregion


        #region SaveAdd

        [HttpPost]
        public IActionResult SaveAdd([FromForm] CourseDto courseDto)
        {
           
            if (ModelState.IsValid)
            {
               
                if (courseDto.ImageFile != null)
                {
                   
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + courseDto.ImageFile.FileName;
                    string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, "upload"); 
                    string imgFullPath = Path.Combine(uploadPath, uniqueFileName);

                   
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    using (FileStream fileStream = new FileStream(imgFullPath, FileMode.Create))
                    {
                        courseDto.ImageFile.CopyTo(fileStream);
                    }

                    courseDto.Imagepath = "/upload/" + uniqueFileName;
                }

               
                var course = mapper.Map<Course>(courseDto);

                context.Courses.Add(course);
                context.SaveChanges();
  
                return RedirectToAction("Index");
            }
            else
            {
                // If the model state is invalid, reload the instructors list and return the form view
                ViewData["Instructor_list"] = context.Instructors.ToList();
                return View("AddNew");
            }
        }
        #region ChatGpt
        //[HttpPost]
        //public IActionResult SaveAdd([FromForm] CourseDto courseDto)
        //{
        //    if (ModelState.IsValid == true)
        //    {
        //        if (courseDto.ImageFile != null)
        //        {
        //            string imgePath = "//upload//" + Guid.NewGuid() + courseDto.ImageFile.FileName;
        //            string imgFullPath = webHostEnvironment.WebRootPath + imgePath;
        //            FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
        //            courseDto.ImageFile.CopyTo(fileStream);
        //            fileStream.Dispose();

        //            courseDto.Imagepath = imgePath;


        //        }
        //        var course = mapper.Map<Course>(courseDto);

        //        context.Courses.Add(course);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // ViewBag.AllDepartments = context.Departments.ToList();
        //        ViewData["Instructor_list"] = context.Instructors.ToList();

        //        return View("AddNew");
        //    }
        //}
        #endregion

        #endregion

        #region Edit
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{

        //    Course course = context.Courses.Include(c => c.Instructors).FirstOrDefault(ins => ins.Id == id);

        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        ViewBag.AllInstructor = context.Instructors.ToList();
        //        return View("Edit", course);
        //    }
        //}

        [HttpGet]
        public IActionResult Edit(int id)
        {
           
            Course? course = context.Courses
                                   .Include(c => c.Instructors)
                                   .FirstOrDefault(c => c.Id == id);
    
            if (course == null)
            {
                return NotFound();
            }

            // Create a CourseDto instance and map the properties
            CourseDto courseDto = new CourseDto
            {
               
                Name = course.Name,
                minDegree = course.minDegree,
                Address = course.Address,
              
            };

           
            ViewBag.AllInstructors = context.Instructors.ToList();

          
            return View("Edit", courseDto);
        }


        #endregion


        #region SaveEdit
        [HttpPost]
        public IActionResult SaveEdit(CourseDto courseDto)
        {
            if (ModelState.IsValid == true)
            {

                if (courseDto.ImageFile != null)
                {

                    if (System.IO.File.Exists(webHostEnvironment.WebRootPath + courseDto.Imagepath))
                    {
                        System.IO.File.Delete(webHostEnvironment.WebRootPath + courseDto.Imagepath);
                    }

                    string imgePath = "//upload//" + Guid.NewGuid() + courseDto.ImageFile.FileName;
                    string imgFullPath = webHostEnvironment.WebRootPath + imgePath;
                    FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
                    courseDto.ImageFile.CopyTo(fileStream);
                    fileStream.Dispose();

                    courseDto.Imagepath = imgePath;


                }
                var coures = mapper.Map<Course>(courseDto);

                context.Courses.Update(coures);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.AllInstructor = context.Instructors.ToList();
                return View("Edit");
            }
        }
        #endregion







    }
}
