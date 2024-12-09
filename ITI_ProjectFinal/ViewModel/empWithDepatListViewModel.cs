using ITI_ProjectFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ITI_ProjectFinal.ViewModel
{
    public class empWithDepatListViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public string Address { get; set; }
        public string ImageUrl { get; set; }

        public string JobTitle { get; set; }

        [ForeignKey("department")]
        [Display(Name= "Departments")]
        public int DepartmentiD { get; set; }
        public Department department { get; set; }

        public ICollection<Department> Departmentlist { get; set; }
    }
}
