using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieWise.Api.Features.Meal.Update.V1
{
    public sealed class MealUpdateEndpoint(IMealUpdateService service) : Endpoint<MealUpdateRequest, Results<Ok<MealUpdateResponse>, ProblemDetails>, MealUpdateMapper>
    {
        public override void Configure()
        {
            Put("/meal/update");
            Summary(s =>
            {
                s.ExampleRequest = new MealUpdateRequest { };
            });
        }

        public override async Task<Results<Ok<MealUpdateResponse>, ProblemDetails>> ExecuteAsync(MealUpdateRequest r, CancellationToken c)
        {
            {
                var update = await service.UpdateMeal(r);

                if (update == null)
                {
                    AddError("Supplied MealId does not return a matching database record");
                    return new ProblemDetails(ValidationFailures);
                }

                return TypedResults.Ok(Map.FromEntity(update));
            }
        }
    }
}