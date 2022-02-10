using Banking.API.Entities;

namespace Banking.API.Models
{
    public class AccountDetailsCreateRepo
    {
        public string? AccountNumber { get; set; }
        public AccountType Account { get; set; }
        public ICollection<Users> Users { get; set; }
         = new List<Users>();
    }
}
