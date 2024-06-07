using System.ComponentModel.DataAnnotations;

namespace Blogedium_api.Modals
{
    public class UserModal
    {
        [Required]
        [Key]
        public int Id {get; set;}
        
        [Required(ErrorMessage = "Eamil address is required")]
        [EmailAddress]
        public string EmailAddress {get; set;}

        [Required(ErrorMessage = "Password is required")]
        public string Password {get; set;}
        public UserRole Role {get; set;} = UserRole.User;

        public UserModal(int id, string emailaddress, string password, UserRole role)
        {
            Id = id;
            EmailAddress = emailaddress;
            Password = password;
            Role = role;
        }
    }
}