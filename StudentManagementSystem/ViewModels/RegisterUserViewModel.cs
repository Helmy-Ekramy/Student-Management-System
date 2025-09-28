using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invaild Email Address")]
        public string Email { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required.")]
        //[RegularExpression(@"^(?=.{8,}$)(?=.*[A-Za-z])(?=.*\d)[A-Za-z0-9]+$",
        //ErrorMessage = "Password must be at least 8 characters, contain at least one letter and one number, and use only letters and digits.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string Address { get; set; }
    }
}
