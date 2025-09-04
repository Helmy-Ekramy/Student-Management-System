using StudentManagementSystem.Context;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Validators
{
    public class UniqueDeptName:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            StudentManagementContext db = new StudentManagementContext();
            string name = value as string;

          var dept=  db.Departments.FirstOrDefault(a => a.Name == value);
            if (dept != null)
            {
               return new ValidationResult("Department Is already Exist");
            }
            return ValidationResult.Success;

        }
    }
}
