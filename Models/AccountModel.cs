using System.ComponentModel.DataAnnotations;

namespace NetCoreApi.Models
{
    public class AccountModel
    {
        public int? Id { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(8)]
        public string Username { get; set; }
        [Required]
        [MaxLength(15)]
        [MinLength(8)]
        public string Password { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        public string? PhoneNumber { get; set; } 
        public string? NewPassword { get; set; }
        
    }
}
