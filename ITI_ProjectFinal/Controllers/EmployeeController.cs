using ITI_ProjectFinal.Models;
using ITI_ProjectFinal.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ITI_ProjectFinal.Controllers
{
    public class EmployeeController : Controller
    {
        public ITIContext context = new ITIContext();

        public EmployeeController() { }
        public IActionResult Details(int id)
        {

            string meg = "Hellow my Frind";
            int Temp = 23;
            List<string> branches = new List<string>();

            branches.Add("Assuit");
            branches.Add("Fayoum");
            branches.Add("Cairo");
            branches.Add("Alex"); // for send all this info cant use view but use viewdata is a dectionary inhert from controller base -> httpcontext endpoint
                                  // viewdata(Key, obj)  for addtional info
            ViewData["Mes"] = meg;
            ViewData["Temp"] = Temp;
            ViewData["brch"] = branches;

            Employee employee = context.Employees.SingleOrDefault(d => d.Id == id);

            return View("Details", employee);  //old option




        }

        //---------------Youse hamdy
        [HttpPost]
        public IActionResult AddNew(Employee employee)
        {
            if (ModelState.IsValid == true)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return RedirectToAction("Details");
            }
            else
            {

                return View("AddNew");
            }
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", context.Employees.ToList());
        }







        [HttpGet] // takeCare it get not post 
        public IActionResult Edit(int id)
        {

            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id); 

            List<Department> departmentListDB = context.Departments.ToList();
            //------------Create ViewModel Mapping ---
            empWithDepatListViewModel empViewModel = new empWithDepatListViewModel();

            empViewModel.Id = emp.Id;
            empViewModel.Name = emp.Name;
            empViewModel.JobTitle = emp.JobTitle;
            empViewModel.Salary = emp.Salary;
            empViewModel.Address = emp.Address;
           // empViewModel.DepartmentiD = emp.;
            empViewModel.ImageUrl = emp.ImageUrl;

            empViewModel.Departmentlist = departmentListDB;
          //  context.SaveChanges();
         
            return View("Edit", empViewModel);


        }
        #region SaveEdit
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SaveEdit(Employee empFromRequest, int id)
        //{
        //    if (empFromRequest == null)
        //    {
        //        return BadRequest("Invalid employee data.");
        //    }

        //    try
        //    {
        //         Retrieve the employee from the database
        //        Employee empFromDB = context.Employees.FirstOrDefault(e => e.Id == id);

        //         Check if the employee exists in the database
        //        if (empFromDB == null)
        //        {
        //            return NotFound($"Employee with ID {id} not found.");
        //        }

        //         Update employee properties if they exist
        //        empFromDB.Name = empFromRequest.Name ?? empFromDB.Name;
        //        empFromDB.Salary = empFromRequest.Salary != 0 ? empFromRequest.Salary : empFromDB.Salary;
        //        empFromDB.JobTitle = empFromRequest.JobTitle ?? empFromDB.JobTitle;
        //        empFromDB.Address = empFromRequest.Address ?? empFromDB.Address;
        //        empFromDB.ImageUrl = empFromRequest.ImageUrl ?? empFromDB.ImageUrl;
        //        empFromDB.DepartmentiD = empFromRequest.DepartmentiD != 0 ? empFromRequest.DepartmentiD : empFromDB.DepartmentiD;

        //         Save changes to the database
        //        context.SaveChanges();

        //         Redirect to the index page upon success
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //         Log the exception (optional: add logging)
        //        return BadRequest($"An error occurred: {ex.Message}");
        //    }
        //}
        //-----------------------------------------------

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult SaveEdit(Employee empFromRequest, int id)
        //{
        //    if (empFromRequest == null)
        //    {
        //        return BadRequest("Invalid employee data.");
        //    }

        //    Employee empFromDB = context.Employees.FirstOrDefault(e => e.Id == id);

        //    if (empFromDB == null)
        //    {
        //        return NotFound("Employee not found.");
        //    }

        //    empFromDB.Name = empFromRequest.Name;
        //    empFromDB.Salary = empFromRequest.Salary;
        //    empFromDB.JobTitle = empFromRequest.JobTitle;
        //    empFromDB.Address = empFromRequest.Address;
        //    empFromDB.ImageUrl = empFromRequest.ImageUrl;
        //    empFromDB.DepartmentiD = empFromRequest.DepartmentiD;

        //    context.SaveChanges();

        //    return RedirectToAction("Index");
        //}
        #endregion


        #region SaveEditUse

        [HttpPost]
        public IActionResult SaveEdit(int id, empWithDepatListViewModel empFromRequest)
        {
            if (empFromRequest == null)
            {
                return BadRequest("Invalid employee data.");
            }

            Employee empFromDB = context.Employees.FirstOrDefault(e => e.Id == id);

            if (empFromDB == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            if (empFromDB.Name != null)
            {
                empFromDB.Name = empFromRequest.Name;
                empFromDB.Salary = empFromRequest.Salary;
                empFromDB.JobTitle = empFromRequest.JobTitle;
                empFromDB.Address = empFromRequest.Address;
                empFromDB.ImageUrl = empFromRequest.ImageUrl;
            //   empFromDB.DepartmentiD = empFromRequest.DepartmentiD;

                empFromRequest.Departmentlist = context.Departments.ToList();  // to avoid dep_list = Null 

                context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View("Edit", empFromRequest);



        }
        #endregion

        [HttpGet]
        public IActionResult AddNew()
        {

            //List<Department> department_listDb = context.Departments.ToList();

            //empWithDepatListViewModel empFromRequest = new empWithDepatListViewModel();

            //empFromRequest.Id = empFromDb.Id;
            //empFromRequest.Name = empFromDb.Name;
            //empFromRequest.Salary = empFromDb.Salary;
            //empFromRequest.Address = empFromDb.Address;
            //empFromRequest.ImageUrl = empFromDb.ImageUrl;
            //empFromRequest.DepartmentiD = empFromDb.DepartmentiD;

            //empFromRequest.Departmentlist = department_listDb;

            ViewData["Deptlist"] = context.Departments.ToList(); // insted of using viewModel
            //in view loop of this list 
            return View("AddNew");
        }

        [HttpPost]
        public IActionResult SaveAdd(string name , Employee emplFromRequest)
        {

            if (emplFromRequest.Name != null && emplFromRequest.Salary >= 2000)
            {
                context.Employees.Add(emplFromRequest);


                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Deptlist"] = context.Departments.ToList(); // call it if occure error 
              //  ViewData["Deptlist"] = new SelectList(ViewBag.Deptlist, "Id", "Name"); can use it too 
                return View("AddNew", emplFromRequest);
            }    
        }
    }
}
