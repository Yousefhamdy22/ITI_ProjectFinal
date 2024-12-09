using AutoMapper;
using ITI_ProjectFinal.DTOs;
using ITI_ProjectFinal.Models;


namespace ITI_ProjectFinal.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles ()
        {
            CreateMap<Course, CourseDto>(); // source to destination
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Student, StudentDto >();
            CreateMap<Instructor, InstructorDto>();
            CreateMap<Trainee, TraineeDto>();

        }


    }
}
