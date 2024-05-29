namespace CalorieWise.Api.Features.Meal.Delete.V1
{
    public interface IMealDeleteService
    {
        Task DeleteMealAsync(MealDeleteRequest r);
    }
}