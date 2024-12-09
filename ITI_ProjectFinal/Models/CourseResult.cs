using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ITI_ProjectFinal.Models
{
    public class CourseResult
    {

       

        public int CourseResultID { get; set; }
        public string Result { get; set; } // E.g., Pass/Fail or a Grade

        // Foreign keys to Trainee and Course

        [ForeignKey("Trainee")]
        [Display(Name = "Trainee")]
        public int TraineeID { get; set; }
        public Trainee Trainee { get; set; } // Navigation to Trainee

        

        [ForeignKey("Instructor")]
        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }


        [ForeignKey("Course")]
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Student")]
        [Display(Name = "Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
