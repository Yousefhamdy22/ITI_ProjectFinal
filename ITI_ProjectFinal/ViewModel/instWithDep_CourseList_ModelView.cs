using ITI_ProjectFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ITI_ProjectFinal.ViewModel
{
    public class instWithDep_CourseList_ModelView
    {
        public int id { get; set; }

        [Display( Name = "Full Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string? Address { get; set; }

        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }


        [Display(Name = "Courses")]
        public int CourseID { get; set; }
        public Course Course { get; set; }
        [Display(Name = "Departments")]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public ICollection<Department> department_List { get; set; }

        public ICollection<Course> course_List { get; set; }
    }
}
