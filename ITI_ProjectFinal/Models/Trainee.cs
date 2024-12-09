using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_ProjectFinal.Models
{
    public class Trainee
    {


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public float Stuts { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Department> Departments { get; set; } // Many-to-many navigation to Department
        public ICollection<CourseResult> CourseResults { get; set; }



        ////[ForeignKey("Course_Resulte")]
        ////public int Course_ResulteID { get; set; }

        ////[ForeignKey("Course")]
        ////public int CourseID { get; set; }
        ////public Course Course { get; set; }
        ////public Course_Resulte Course_Resulte { get; set; }

        ////[ForeignKey("Department")]
        ////public int DepartmentID { get; set; }
        ////public Department Department { get; set; }
        //  public ICollection<Department> Departments { get; set; }

    }
}
