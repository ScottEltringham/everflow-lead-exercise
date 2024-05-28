namespace CalorieWise.Api.Features.Meal.Create.V1
{
    public interface IMealCreateService
    {
        Task CreateNewMeal(Data.Models.Meal meal);
    }
}
