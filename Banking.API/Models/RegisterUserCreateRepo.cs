using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class RegisterUserCreateRepo
    {
      
        public string? Emailaddress { get; set; }
       
        public string? UserName { get; set; }
        
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}
