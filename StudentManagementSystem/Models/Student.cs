using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace StudentManagementSystem.Models;
public class Student
{
    public int Id { get; set; }
    [RegularExpression("[a-z-A-Z ]{3,20}", ErrorMessage = "Name must be grater than 3 chars and less than 20 chars")]
    [Required]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, DataType(DataType.Date)]
    [Remote("TestDOB","Student",ErrorMessage ="Age Must be between 18 and 25")]
    public DateTime DateOfBirth { get; set; }

    [ForeignKey(nameof(Department))]
    [Required]
    public int DepartmentId { get; set; }

    public Department? Department { get; set; }

    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public List<Attendance> Attendances { get; set; } = new List<Attendance>();

    [Display(Name ="Student Image")]
    public string ? StudentImage { get; set; }

}
