using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_ProjectFinal.Models
{
    public class Course
    {


        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
     

        public string Address { get; set; }
        public float minDegree { get; set; }

       public string Imagepath { get; set; }

        //[NotMapped]
        //[ValidateNever]
        //public IFormFile ImageFile { get; set; } // use with Dto 
       



        public ICollection<Student> Students { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<CourseResult> CourseResults { get; set; }

       

    }
}
