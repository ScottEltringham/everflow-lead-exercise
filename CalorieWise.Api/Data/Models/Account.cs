namespace CalorieWise.Api.Data.Models
{
    public class Account
    {
        public long Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; init; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
