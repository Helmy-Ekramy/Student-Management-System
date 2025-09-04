using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;
namespace StudentManagementSystem.Context

{
    public class StudentManagementContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HELMY_EKRAMY\\SQLEXPRESS;Database=StudentManagement;Trusted_Connection=true;Encrypt=false");
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
    }
}
