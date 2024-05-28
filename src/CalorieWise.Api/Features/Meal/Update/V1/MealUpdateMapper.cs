using CalorieWise.Api.Data.Models;

namespace CalorieWise.Api.Features.Meal.Update.V1
{
    public sealed class MealUpdateMapper : Mapper<MealUpdateRequest, MealUpdateResponse, Data.Models.Meal>
    {
        public override Data.Models.Meal ToEntity(MealUpdateRequest r)
        {
            return new Data.Models.Meal()
            {
                Id = new MealId(r.MealID),
                MealName = r.MealName,
                MealDescription = r.MealDescription,
                MealDate = r.MealDate,
                Calories = r.Calories
            };
        }

        public override MealUpdateResponse FromEntity(Data.Models.Meal e)
        {
            return new MealUpdateResponse()
            {
                MealID = e.Id.Value,
                MealName = e.MealName,
                MealDescription = e.MealDescription, 
                MealDate = e.MealDate, 
                Calories = e.Calories
            };
        }
    }
}