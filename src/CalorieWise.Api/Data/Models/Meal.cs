namespace CalorieWise.Api.Data.Models
{ 
    public record struct MealId(long Value);
    public class Meal
    {
        public MealId Id { get; init; }

        public AccountId AccountId { get; set; }
        public virtual Account Account { get; set; }

        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public int Calories { get; set; }
        public DateOnly MealDate { get; set; }
    }
}
