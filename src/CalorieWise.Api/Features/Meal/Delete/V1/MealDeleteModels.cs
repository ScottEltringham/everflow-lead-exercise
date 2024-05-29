namespace CalorieWise.Api.Features.Meal.Delete.V1
{
    public sealed class MealDeleteRequest
    {
        public long MealId { get; set; }
    }

    public sealed class MealDeleteResponse
    {
        public string Message => "Meal has been deleted.";
    }
}
