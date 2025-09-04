using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models;


public class Course
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; }

    [Required,Range(1, 3)]

    public int Credits { get; set; }

    public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public List<Attendance> Attendances { get; set; } = new List<Attendance>();
}
