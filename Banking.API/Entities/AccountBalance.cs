using System.ComponentModel.DataAnnotations;

namespace Banking.API.Entities
{
    public class AccountBalance
    {
        [Key]
        public Guid Id { get; set; }
       
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
