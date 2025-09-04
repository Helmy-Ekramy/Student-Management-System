using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace StudentManagementSystem.Models;


public class Department
{
    public int Id { get; set; }
    [Required]
    [RegularExpression("[a-z-A-Z0-9 ]{2,25}", ErrorMessage = "Department Name must be grater than 2 chars and less than 25 chars")]
    [Remote("TestDeptName","Department", ErrorMessage ="Department Is already Exists!")]
    public string Name { get; set; }

    public List<Student> Students { get; set; }= new List<Student>();
}
