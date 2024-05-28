using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Interfaces;

namespace CalorieWise.Api.Features.Meal.Update.V1
{
    public class MealUpdateService(
        IReadRepository<Data.Models.Meal, Data.Models.MealId, CalorieWiseDbContext> readRepository,
        IUpdateRepository<Data.Models.Meal, CalorieWiseDbContext> updateRepository) : IMealUpdateService
    {
        public async Task<Data.Models.Meal> UpdateMeal(MealUpdateRequest r)
        {
            var toUpdate = await readRepository.GetByIdAsync(new Data.Models.MealId(r.MealID));

            if (toUpdate != null)
            {
                toUpdate.MealName = r.MealName;
                toUpdate.MealDescription = r.MealDescription;
                toUpdate.Calories = r.Calories;
                toUpdate.MealDate = r.MealDate;

                await updateRepository.UpdateAsync(toUpdate);

                return toUpdate;
            }

            return null;
        }
    }
}
