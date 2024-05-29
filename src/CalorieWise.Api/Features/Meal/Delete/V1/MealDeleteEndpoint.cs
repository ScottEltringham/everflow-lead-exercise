namespace CalorieWise.Api.Features.Meal.Delete.V1
{
    public sealed class MealDeleteEndpoint(IMealDeleteService service) : Endpoint<MealDeleteRequest, MealDeleteResponse>
    {
        public override void Configure()
        {
            Delete("/meal/delete");
        }

        public override async Task HandleAsync(MealDeleteRequest r, CancellationToken c)
        {
            await service.DeleteMealAsync(r);

            await SendAsync(new MealDeleteResponse());
        }
    }
}