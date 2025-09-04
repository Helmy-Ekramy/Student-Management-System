using System;
using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models;


public class Instructor
{
    public int Id { get; set; }
    [RegularExpression("[a-z-A-Z]{3,20}", ErrorMessage = "Name must be grater than 3 chars and less than 20 chars")]
    [Required]
    public string Name { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime HireDate { get; set; }

    public OfficeAssignment? OfficeAssignment { get; set; }
}
