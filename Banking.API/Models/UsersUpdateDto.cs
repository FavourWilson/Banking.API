namespace Banking.API.Models
{
    public class UsersUpdateDto
    {
        public string? Name { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
        public string? MotherMaidenName { get; set; }
        public string? NextOfKin { get; set; }
        public string? Phonenumber { get; set; }
        public string? EmailAddress { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
