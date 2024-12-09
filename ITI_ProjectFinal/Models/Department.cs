using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_ProjectFinal.Models
{ 
    public class Department
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public string? ManagerName { get; set; }
        public string? Description { get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<Trainee> Trainees { get; set; } 
        public ICollection<Instructor> instructors { get; set; } 


       
        //public ICollection<Trainee> Trainees { get; set; }
        // public ICollection<Employee>? Employees { get; set; }
        // public ICollection<Instructor>? instructors { get; set; }
    }
}
