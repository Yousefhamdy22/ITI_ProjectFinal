namespace ITI_ProjectFinal.DTOs
{
    public class EmployeeDto
    {

        public string Name { get; set; }
        public decimal Salary { get; set; }

        public string Address { get; set; }
        public string ImageUrl { get; set; }

        public string JobTitle { get; set; }
        public IFormFile ImageFile { get; set; }


    }
}
