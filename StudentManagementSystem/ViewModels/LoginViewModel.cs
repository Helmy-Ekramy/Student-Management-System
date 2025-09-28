using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }


        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }


        [DisplayName("Remember Me ")]
        public bool RememberMe { get; set; }
    }
}
