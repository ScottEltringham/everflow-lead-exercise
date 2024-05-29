namespace CalorieWise.Api.Features.Meal.ReadAll.V1
{
    internal sealed class MealReadAllEndpoint(IMealReadAllService service) : Endpoint<MealReadAllRequest, IEnumerable<MealReadAllResponse>, MealReadAllMapper>
    {
        public override void Configure()
        {
            Get("/meal/getall");
        }

        public override async Task HandleAsync(MealReadAllRequest r, CancellationToken c)
        {
            var result = await service.GetAllAsync(r);
            Response = Map.FromEntity(result);
        }
    }
}