using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Entities
{
    public class Users
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Firstname { get; set; }
        [Required]
        [StringLength(100)]
        public string? Lastname { get; set; }
        [Required]
        [StringLength(100)]
        public string? Middlename { get; set; }
        [Required]
        public DateTimeOffset DateOfBirth { get; set; }
        [Required]
        public string? MotherMaidenName  { get; set; }
        [Required]

        public string? NextOfKin { get; set; }
        [Required, StringLength(11)]
        public string? PhoneNumber { get;set; }
        [Required,StringLength(250)]
        public string? Emailaddress { get; set; }
        [Required]
        [MinLength(5)]
        public string? Username { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }

    }
}
