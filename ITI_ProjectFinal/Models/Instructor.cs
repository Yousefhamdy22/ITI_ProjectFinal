using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_ProjectFinal.Models
{
    public class Instructor
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public string? Address { get; set; }
        public string ImageUrl { get; set; }


        public ICollection<Department> Departments { get; set; }
        public ICollection<CourseResult> CourseResults { get; set; }


        //[ForeignKey("Course")]
        //public int CourseID { get; set; }
        //public Course Course { get; set; }

        //[ForeignKey("Department")] //note 

        //public int DepartmentID { get; set; }
        //public Department Department { get; set; }

    }
}
