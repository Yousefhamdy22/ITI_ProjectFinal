namespace ITI_ProjectFinal.DTOs
{
    public class InstructorDto
    {

        public string Name { get; set; }
        public decimal Salary { get; set; }

        public string? Address { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile ImageFile { get; set; }


    }
}
