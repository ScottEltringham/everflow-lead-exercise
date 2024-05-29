using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Models;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Meal.ReadAll.V1
{
    public class MealReadAllService(IReadRepository<Data.Models.Meal, MealId, CalorieWiseDbContext> readRepository) : IMealReadAllService
    {
        public async Task<IEnumerable<Data.Models.Meal>> GetAllAsync(MealReadAllRequest request)
        {
            var meals = readRepository.GetAllQueryable(x => x.AccountId == new AccountId(request.AccountId));

            return meals.ToList();
        }
    }
}
