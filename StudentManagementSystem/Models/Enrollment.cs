using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagementSystem.Models;


public class Enrollment
{
    public int Id { get; set; }

    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    [Range(0, 100)]
    public double?  Grade { get; set; }

    public string? result { get; set; } = "Not Announced";
    public string? resultClass { get; set; } = "text-dark";

}
