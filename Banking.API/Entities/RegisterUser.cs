using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Banking.API.Entities
{
    public class RegisterUser : IdentityUser
    {
        [Required, StringLength(250)]
        public string? Emailaddress { get; set; }
        [Required]
        [MinLength(8)]
        public override string? UserName { get; set; }
        [Required]
        [MinLength(8)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "The password do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
