using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Entities
{
    public class AccountDetails
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(10)]
        public string? AccountNumber { get; set; }
        [Required]
        public AccountType Account { get; set; }
        public Guid Userid { get; set; }

        public Users? Users { get; set; }


    }
}
