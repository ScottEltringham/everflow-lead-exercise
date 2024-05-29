using CalorieWise.Api.Features.Meal.Delete.V1;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System.Net;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Features.Meal.Delete.V1
{
    public class MealDeleteEndpointTests(Sut app) : TestBase<Sut>
    {
        [Fact]
        public async Task MealDeleteEndpoint_ShouldDeleteMeal_WhenRequestIsValid()
        {
            var (httpResponse, _) = await app.Client.DELETEAsync<MealDeleteEndpoint, MealDeleteRequest, MealDeleteResponse>(new()
            {
                MealId = 1L
            });

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
