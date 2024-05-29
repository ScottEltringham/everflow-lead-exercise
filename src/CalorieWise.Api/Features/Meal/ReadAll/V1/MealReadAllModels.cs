namespace CalorieWise.Api.Features.Meal.ReadAll.V1
{
    public sealed class MealReadAllRequest
    {
        public long AccountId { get; init; }
    }

    public sealed class MealReadAllResponse
    {
        public long MealId { get; init; }
        public string MealName { get; init; }
        public string MealDescription { get; init; }
        public int Calories { get; init; }
        public DateOnly MealDate { get; init; }
    }
}
