using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Meal.Delete.V1
{
    public class MealDeleteService(IDeleteRepository<Data.Models.Meal, Data.Models.MealId, CalorieWiseDbContext> deleteRepository) : IMealDeleteService
    {
        public async Task DeleteMealAsync(MealDeleteRequest r)
        {
            await deleteRepository.DeleteAsync(new Data.Models.MealId(r.MealId));
        }
    }
}
