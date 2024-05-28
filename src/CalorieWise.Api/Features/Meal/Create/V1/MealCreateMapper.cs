using CalorieWise.Api.Data.Models;

namespace CalorieWise.Api.Features.Meal.Create.V1
{
    public sealed class MealUpdateMapper : Mapper<MealCreateRequest, MealCreateResponse, Data.Models.Meal>
    {
        public override Data.Models.Meal ToEntity(MealCreateRequest r)
        {
            return new Data.Models.Meal()
            {
                AccountId = new AccountId(r.AccountID),
                MealName = r.MealName,
                MealDescription = r.MealDescription,
                MealDate = r.MealDate,
                Calories = r.Calories
            };
        }

        public override MealCreateResponse FromEntity(Data.Models.Meal e)
        {
            return new MealCreateResponse()
            {
                MealID = e.Id.Value,
                MealName = e.MealName,
            };
        }
    }
}