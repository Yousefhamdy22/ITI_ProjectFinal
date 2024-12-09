using System.ComponentModel.DataAnnotations;

namespace ITI_ProjectFinal.DTOs
{
    public class CourseDto
    {

        public string Name { get; set; }

        public string Address { get; set; }
        public float minDegree { get; set; }

        public string Imagepath { get; set; }

        public IFormFile ImageFile { get; set; }

        [Display(Name="Instructors")]
        public int InstructorId { get; set; } // relation

    }
}
