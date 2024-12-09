using Microsoft.EntityFrameworkCore;

namespace ITI_ProjectFinal.Models
{
    public class ITIContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=finalProjectITI; Integrated Security=True; Trusted_connection = true ; TrustServerCertificate=True");


            }
        }
        public ITIContext(DbContextOptions<ITIContext> options)
           : base(options)
        {
        }

        public ITIContext():base()
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

              modelBuilder.Entity<Department>()
             .HasMany(e => e.Employees)
             .WithMany(d => d.Departments)
             .UsingEntity(j => j.ToTable("EmployeeDepartment"));
            
              modelBuilder.Entity<Department>()
            .HasMany(i => i.instructors)
            .WithMany(d => d.Departments)
            .UsingEntity(j => j.ToTable("InstructorDepartment"));

            modelBuilder.Entity<Department>()
           .HasMany(i => i.Trainees)
           .WithMany(d => d.Departments)
           .UsingEntity(j => j.ToTable("TraineeDepartment"));


            modelBuilder.Entity<Student>()
            .HasMany(i => i.Courses)
            .WithMany(d => d.Students)
            .UsingEntity(j => j.ToTable("StudentCourse"));

            modelBuilder.Entity<CourseResult>()
          .HasOne(cr => cr.Trainee)
          .WithMany(t => t.CourseResults)
          .HasForeignKey(cr => cr.TraineeID);

            // Instructor to CourseResult: one-to-many
            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Instructor)
                .WithMany(i => i.CourseResults)
                .HasForeignKey(cr => cr.InstructorId);

            // Course to CourseResult: one-to-many
            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Course)
                .WithMany(c => c.CourseResults)
                .HasForeignKey(cr => cr.CourseId);

            // Student to CourseResult: one-to-many
            modelBuilder.Entity<CourseResult>()
                .HasOne(cr => cr.Student)
                .WithMany(s => s.CourseResults)
                .HasForeignKey(cr => cr.StudentId);








            base.OnModelCreating(modelBuilder);


        }


        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<Student> Students { get; set; }
        
        public DbSet<Trainee> Trainees { get; set; }
        


        
    
    }
}
