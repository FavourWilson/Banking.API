namespace Banking.API.Models
{
    public class AccountBalUpdateDto
    {
        public string? Acctnumber { get; set; }
        public decimal Deposit { get; set; }
        
        public decimal Withdrawal { get; set; }
        
        public decimal TotalBalance { get; set; }
        public DateTimeOffset DateOftransaction { get; set; }
    }
}
