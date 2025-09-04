using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagementSystem.Models;


public class Attendance
{
    public int Id { get; set; }

    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    public Student? Student { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }

    public Course? Course { get; set; }

    [Required, DataType(DataType.Date)]
    public DateOnly Date { get; set; }

    public bool IsPresent { get; set; }=true; // assume
}
