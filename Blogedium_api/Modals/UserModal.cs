using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Blogedium_api.Modals
{
    public class UserModal
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.User; // Default role set to User

        // Empty constructor required by EF Core for migrations and queries
        public UserModal() {}
    }
}
