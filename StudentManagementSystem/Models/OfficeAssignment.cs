using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StudentManagementSystem.Models;

public class OfficeAssignment
{
    [Key, ForeignKey(nameof(Instructor))]
    public int InstructorId { get; set; }

    [Required, StringLength(100)]
    public string Location { get; set; }

    public Instructor Instructor { get; set; }
}
