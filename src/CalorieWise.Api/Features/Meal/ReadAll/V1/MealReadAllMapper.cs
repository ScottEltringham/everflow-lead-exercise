namespace CalorieWise.Api.Features.Meal.ReadAll.V1
{
    public sealed class MealReadAllMapper : ResponseMapper<IEnumerable<MealReadAllResponse>, IEnumerable<Data.Models.Meal>>
    {
        public override IEnumerable<MealReadAllResponse> FromEntity(IEnumerable<Data.Models.Meal> e)
        {
            return e.Select(x => new MealReadAllResponse
            {
               MealId = x.Id.Value,
               MealName = x.MealName,
               MealDescription = x.MealDescription,
               Calories = x.Calories,
               MealDate = x.MealDate
            });
        }
    }
}