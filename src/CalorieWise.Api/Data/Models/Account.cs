namespace CalorieWise.Api.Data.Models
{
    public record struct AccountId(long Value);
    public class Account
    {
        public AccountId Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; init; }
        public string Password { get; set; }
        public DateTime DateCreated { get; set; }

        public ICollection<Meal> Meals { get; set; } = [];
    }
}
