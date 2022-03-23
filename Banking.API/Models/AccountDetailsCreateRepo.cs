using Banking.API.Entities;

namespace Banking.API.Models
{
    public class AccountDetailsCreateRepo
    {
        public Guid Userid { get; set; }

        public string? AccountNumber { get; set; }
        public AccountType Account { get; set; }

    }
}
