namespace CalorieWise.Api.Features.Meal.Create.V1
{
    public interface IMealCreateService
    {
        Task<bool> CreateNewMeal(Data.Models.Meal meal);
    }
}
