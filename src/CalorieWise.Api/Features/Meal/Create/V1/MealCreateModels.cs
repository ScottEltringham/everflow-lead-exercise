using FluentValidation;

namespace CalorieWise.Api.Features.Meal.Create.V1
{
    public sealed class MealCreateRequest
    {
        public long AccountID { get; set; }
        public string MealName { get; set; } = string.Empty;
        public string MealDescription { get; set; } = string.Empty;
        public int Calories { get; set; }
        public DateOnly MealDate { get; set; }
    }

    public sealed class MealCreateValidator : Validator<MealCreateRequest>
    {
        public MealCreateValidator()
        {
            RuleFor(x => x.AccountID)
                .NotEmpty().WithMessage("AccountID is required");

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

    public sealed class MealCreateResponse
    {
        public long MealID { get; init; }
        public string MealName { get; set; }
    }
}
