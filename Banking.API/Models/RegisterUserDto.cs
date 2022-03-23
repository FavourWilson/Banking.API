using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class RegisterUserDto
    {
        [Required, StringLength(250)]
        public string? Emailaddress { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
