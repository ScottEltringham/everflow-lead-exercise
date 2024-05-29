namespace CalorieWise.Api.Features.Meal.Delete.V1
{
    internal interface IMealDeleteService
    {
        Task DeleteMealAsync(MealDeleteRequest r);
    }
}