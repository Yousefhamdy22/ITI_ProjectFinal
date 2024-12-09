using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_ProjectFinal.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public string Address { get; set; }
        public string ImageUrl { get; set; }

        public string JobTitle { get; set; }

        public ICollection<Department> Departments { get; set; }

        //[ForeignKey("department")]
        //[Display(Name="Department")]
        //public int DepartmentiD { get; set; }
        //public Department department { get; set; }

        //----------------------




    }
}
