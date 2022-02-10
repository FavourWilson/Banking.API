using Banking.API.Entities;

namespace Banking.API.Models
{
    public class AccountDetailsDto
    {
        public string? AccountNumber { get; set; }
        public AccountType Account { get; set; }
        public ICollection<Users> Users { get; set; }
         = new List<Users>();
    }
}
