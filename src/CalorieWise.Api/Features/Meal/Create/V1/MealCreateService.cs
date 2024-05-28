using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Meal.Create.V1
{
    public class MealCreateService(ICreateRepository<Data.Models.Meal, CalorieWiseDbContext> createRepository) : IMealCreateService
    {
        public async Task CreateNewMeal(Data.Models.Meal meal)
        {
            await createRepository.AddAsync(meal);
        }
    }
}
