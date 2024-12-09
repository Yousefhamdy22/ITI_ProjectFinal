namespace ITI_ProjectFinal.Models
{
    public class Student
    {

        public int Id { get; set; }
        public string  Name { get; set; }

        public string  Address { get; set; }
        public  string ImageUrl { get; set; }

        public string Degree { get; set; }

        public ICollection<Course> Courses { get; set; }
        public ICollection<CourseResult> CourseResults { get; set; }



    }
}
