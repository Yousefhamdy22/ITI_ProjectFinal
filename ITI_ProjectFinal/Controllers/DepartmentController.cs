using ITI_ProjectFinal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITI_ProjectFinal.Controllers
{
    public class DepartmentController : Controller
    {
         public ITIContext context = new ITIContext();  
        public IActionResult GetAll()
        {
            List<Department> Dept_list_Model = context.Departments.Include(d => d.Employees).ToList();
            
            return View("GetAll", Dept_list_Model);
        }

        public IActionResult Index()
        {
            List<Department> dep_list = context.Departments.Include(d => d.Employees).ToList();
            return View("Index", dep_list);
        }

        // if to actoin use the same view one return null and 
        // another return model let any class use ? to handle this exc
        public IActionResult Add() 
        {
            return View("Add");
        }

        public IActionResult SaveAdd(Department newDepFromRequset)
        {
            if(newDepFromRequset.Name != null)
            {
                context.Departments.Add(newDepFromRequset);
                context.SaveChanges();
                // return View("GetAll");  // will give excption 
                // return View("GetAll", context.Departments.ToList()); // to handle exc 
                //when wnat to call action in anohter actoin use -> redirectaction
                return RedirectToAction("Index");

            }
            return View("Add");
        }
    }
}
