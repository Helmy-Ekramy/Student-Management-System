using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.ViewModels
{
    public class StudentDetailsModel
    {
       //public Student Student { get; set; }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string DepartmentName { get; set; }

        public string StudentImage { get; set; }

        public List<EnrollmentDetailsModel> Enrollments { get; set; }

    }
}
