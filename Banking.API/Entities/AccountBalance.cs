using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Entities
{
    public class AccountBalance
    {
        [Key]
        public Guid Id { get; set; }
       
        public decimal Deposit { get; set; }
        public decimal Withdrawal { get; set; }
        public decimal TotalBalance { get; set; }
        public DateTimeOffset DateOftransaction { get; set; }

        public Guid AccountDetailID { get; set; }
        public AccountDetails? AccountDetails { get; set; }


    }
}
