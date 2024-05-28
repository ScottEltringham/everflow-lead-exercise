using FluentValidation;

namespace CalorieWise.Api.Features.Meal.Update.V1
{
    public sealed class MealUpdateRequest
    {
        public long MealID { get; set; }
        public string MealName { get; set; } = string.Empty;
        public string MealDescription { get; set; } = string.Empty;
        public int Calories { get; set; }
        public DateOnly MealDate { get; set; }
    }

    public sealed class MealCreateValidator : Validator<MealUpdateRequest>
    {
        public MealCreateValidator()
        {
            RuleFor(x => x.MealName)
                .NotEmpty().WithMessage("Meal Name is required");

            RuleFor(x => x.MealDescription)
                .NotEmpty().WithMessage("Meal Description is required");

            RuleFor(x => x.Calories)
                .NotEmpty().WithMessage("Calories is required");

            RuleFor(x => x.MealDate)
                .NotEmpty().WithMessage("Meal Date is required");
        }
    }

    public sealed class MealUpdateResponse
    {
        public long MealID { get; init; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public int Calories { get; set; }
        public DateOnly MealDate { get; set; }
    }
}
