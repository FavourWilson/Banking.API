using Banking.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Banking.API.Models
{
    public class AccountBalCreateRepo
    {
        [Required]
        public decimal Deposit { get; set; }
        [Required]
        public decimal Withdrawal { get; set; }
        [Required]
        public decimal TotalBalance { get; set; }
        [Required]
        public DateTimeOffset DateOftransaction { get; set; }

        public ICollection<AccountDetails> accountDetails { get; set; }
        = new List<AccountDetails>();
    }
}
