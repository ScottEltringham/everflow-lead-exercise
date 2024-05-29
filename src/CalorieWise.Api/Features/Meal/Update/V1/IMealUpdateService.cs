namespace CalorieWise.Api.Features.Meal.Update.V1
{
    public interface IMealUpdateService
    {
        Task<Data.Models.Meal> UpdateMeal(MealUpdateRequest r);
    }
}
