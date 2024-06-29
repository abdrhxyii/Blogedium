using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Blogedium_api.Modals;

namespace Blogedium_api.Modals
{
    public class UserModal
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [EnumDataType(typeof(UserRole))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; } = UserRole.User; // Default role set to User

        // Empty constructor required by EF Core for migrations and queries
        public UserModal() {}
    }
}
