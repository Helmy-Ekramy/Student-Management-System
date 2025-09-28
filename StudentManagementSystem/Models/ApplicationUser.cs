using Microsoft.AspNetCore.Identity;

namespace StudentManagementSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
