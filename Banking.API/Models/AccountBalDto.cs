using Banking.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class AccountBalDto
    {
        [Required]
        public decimal Deposit { get; set; }
        [Required]
        public decimal Withdrawal { get; set; }
        [Required]
        public decimal TotalBalance { get; set; }
        public DateTimeOffset DateOftransaction { get; set; }

        public ICollection<AccountDetails> accountDetails { get; set; }
        = new List<AccountDetails>();
    }
}
