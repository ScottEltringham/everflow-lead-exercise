using CalorieWise.Api.Features.Meal.ReadAll.V1;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System.Net;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Features.Meal.ReadAll.V1
{
    public class MealReadAllEndpointTests(Sut app) : TestBase<Sut>
    {
        [Fact]
        public async Task MealReadAllEndpoint_ShouldReturnAllMeals()
        {
            var (httpResponse, dataResponse) = await app.Client.GETAsync<MealReadAllEndpoint, MealReadAllRequest, IEnumerable<MealReadAllResponse>>(new() { AccountId = 1L });

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            dataResponse.Should().NotBeNullOrEmpty();
            dataResponse.Should().HaveCount(2);
        }
    }
}
