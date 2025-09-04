using StudentManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.ViewModels
{
    public class EnrollmentDetailsModel
    {
        public int Id { get; set; }

        public string CourseName { get; set; }

        public int Credits { get; set; }

        public double? Grade { get; set; }

        public string? result { get; set; } = "Not Announced";
        public string? resultClass { get; set; } = "text-dark";
    }
}
