using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class UsersDto
    {
        
        public Guid Id{ get; set; }
        
        public string? Name { get; set; }
        
        
        public int Age { get; set; }
  
        public string? MotherMaidenName { get; set; }
        

        public string? NextOfKin { get; set; }
       
        public string? PhoneNumber { get; set; }

    }
}
