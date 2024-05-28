using CalorieWise.Api.Features.Account.Create.V1;
using Microsoft.Identity.Client;

namespace CalorieWise.Api.Features.Meal.Create.V1
{
    public sealed class MealUpdateEndpoint(IMealCreateService service) : Endpoint<MealCreateRequest, MealCreateResponse, MealUpdateMapper>
    {
        public override void Configure()
        {
            Post("/meal/create");
            Summary(s =>
            {
                s.ExampleRequest = new MealCreateRequest { };
            });
        }

        public override async Task<MealCreateResponse> ExecuteAsync(MealCreateRequest r, CancellationToken c)
        {
            var entity = Map.ToEntity(r);

            await service.CreateNewMeal(entity);

            return Map.FromEntity(entity);
        }
    }
}