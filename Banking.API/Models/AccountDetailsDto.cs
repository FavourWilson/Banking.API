using Banking.API.Entities;

namespace Banking.API.Models
{
    public class AccountDetailsDto
    {
        public string? AccountNumber { get; set; }
        public AccountType Account { get; set; }
        public Guid Userid { get; set; }

        public Users? Users { get; set; }
    }
}
