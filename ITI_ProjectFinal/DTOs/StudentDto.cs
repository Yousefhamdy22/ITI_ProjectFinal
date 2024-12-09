using ITI_ProjectFinal.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_ProjectFinal.DTOs
{
    public class StudentDto
    {

        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public string Degree { get; set; }
        public string Address { get; set; }

        public IFormFile ImageFile { get; set; }

        [ForeignKey("Courses")]
        [Display(Name ="Courses")]
        public int CourseID { get; set; }
        public ICollection<Course> Course_list { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<CourseResult> CourseResults { get; set; }

    }
}
