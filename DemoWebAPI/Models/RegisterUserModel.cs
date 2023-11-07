using System.ComponentModel.DataAnnotations;

namespace DemoWebAPI.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set;}
        [Required]
        public string Password { get; set; }
    }
}
