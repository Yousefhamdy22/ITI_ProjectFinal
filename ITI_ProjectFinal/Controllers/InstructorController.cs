using AutoMapper;
using ITI_ProjectFinal.DTOs;
using ITI_ProjectFinal.Models;
using ITI_ProjectFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ProjectFinal.Controllers
{
    public class InstructorController : Controller
    {
        // add , index , details
        private readonly ITIContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IMapper mapper;


        public InstructorController(ITIContext _context, IWebHostEnvironment _webHostEnvironment, IMapper _mapper)
        {
            context = _context;
            webHostEnvironment = _webHostEnvironment;
            mapper = _mapper;
        }


        [HttpGet]
        public IActionResult index()
        {
            return View("Index", context.Instructors.ToList());
        }
           
           #region Detials

            [HttpGet]
            public IActionResult Details(int id)
            {
                if (id == null)
                {
                    return BadRequest("Not Found");
                }

                Instructor instructor = context.Instructors.FirstOrDefault(ins => ins.Id == id);

                return View("Details", instructor);
            }
            #endregion


           #region Add
            [HttpGet]
            public IActionResult Add() // instructor + Depatment_list + Course_list
            {
                 ViewData["Department_list"] = context.Departments.ToList();
                 ViewData["Course_list"] = context.Courses.ToList();

                return View("AddNew", new instWithDep_CourseList_ModelView());



            }
        #endregion


           #region SaveAdd
        [HttpPost] 
        public IActionResult SaveAdd([FromForm] instWithDep_CourseList_ModelView insFromRequest)
        {
            if(ModelState.IsValid == false)
            {
                if(insFromRequest.ImageFile != null)
                {
                    string imgePath = "//upload//" + Guid.NewGuid() + insFromRequest.ImageFile.FileName;
                    string imgFullPath = webHostEnvironment.WebRootPath + imgePath;
                    FileStream fileStream = new FileStream(imgFullPath, FileMode.Create);
                    insFromRequest.ImageFile.CopyTo(fileStream);
                      fileStream.Dispose();

                    insFromRequest.ImageUrl = imgePath;

                }

               // Instructor insAddToDB = new Instructor();
                List<Department> department_list = context.Departments.ToList();
                List<Course> course_list = context.Courses.ToList();

                //  Mappnig for adding data and save it

                Instructor insAddToDB = new Instructor
                {
                    Name = insFromRequest.Name,
                    Address = insFromRequest.Address,
                    Salary = insFromRequest.Salary,
                    ImageUrl = insFromRequest.ImageUrl // Set the image path
                };

                context.Instructors.Add(insAddToDB);
                insFromRequest.department_List = department_list; // first of request secode retun DB
                insFromRequest.course_List = course_list;

                context.SaveChanges();
                return RedirectToAction("Index");
                

            }
            else
            {
                ViewData["Department_list"] = context.Departments.ToList();
                ViewData["Course_list"] = context.Courses.ToList();

                return View("AddNew", insFromRequest);
            }
        }

        #region Option
        //public IActionResult SaveAdd([FromForm] instWithDep_CourseList_ModelView insFromRequest)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Handle image upload if file exists
        //        if (insFromRequest.ImageFile != null)
        //        {
        //            string imgePath = "/upload/" + Guid.NewGuid() + Path.GetExtension(insFromRequest.ImageFile.FileName);
        //            string imgFullPath = Path.Combine(webHostEnvironment.WebRootPath, imgePath);

        //            try
        //            {
        //                using (FileStream fileStream = new FileStream(imgFullPath, FileMode.Create))
        //                {
        //                    insFromRequest.ImageFile.CopyTo(fileStream);
        //                }
        //                insFromRequest.ImageUrl = imgePath; // Store relative path
        //            }
        //            catch (Exception ex)
        //            {
        //                ModelState.AddModelError("", "Image upload failed: " + ex.Message);
        //                // Re-populate the lists and return the form if there's an error
        //                ViewData["Department_list"] = context.Departments.ToList();
        //                ViewData["Course_list"] = context.Courses.ToList();
        //                return View("AddNew", insFromRequest);
        //            }
        //        }

        //        // Map the view model to the Instructor entity
        //        Instructor insAddToDB = new Instructor
        //        {
        //            Name = insFromRequest.Name,
        //            Address = insFromRequest.Address,
        //            Salary = insFromRequest.Salary,
        //            ImageUrl = insFromRequest.ImageUrl // Set the image path
        //        };

        //        // Add the instructor to the database context
        //        context.Instructors.Add(insAddToDB);
        //        context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // Handle invalid model state by reloading the view with data
        //        ViewData["Department_list"] = context.Departments.ToList();
        //        ViewData["Course_list"] = context.Courses.ToList();

        //        return View("AddNew", insFromRequest);
        //    }
        //}

        #endregion

        #endregion


    }
}
