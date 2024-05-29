namespace CalorieWise.Api.Features.Meal.ReadAll.V1
{
    public interface IMealReadAllService
    {
        Task<IEnumerable<Data.Models.Meal>> GetAllAsync(MealReadAllRequest request);
    }
}
