using CalorieWise.Api.Features.Meal.Create.V1;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System.Net;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Features.Meal.Create.V1
{
    public class MealCreateEndpointTests(Sut app) : TestBase<Sut>
    {
        [Fact]
        public async Task MealCreateEndpoint_ShouldCreateMeal_WhenRequestIsValid()
        {
            var mealCreateRequest = new MealCreateRequest
            {
                MealName = "Test Meal",
                AccountID = 1L,
                MealDescription = "A delicious test meal",
                Calories = 500,
                MealDate = DateOnly.FromDateTime(DateTime.Now)
            };

            var (httpResponse, dataResponse) = await app.Client.POSTAsync<MealCreateEndpoint, MealCreateRequest, MealCreateResponse>(mealCreateRequest);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            dataResponse.Should().NotBeNull();
            dataResponse.MealName.Should().Be(mealCreateRequest.MealName);
        }

        [Fact]
        public async Task MealCreateEndpoint_ShouldReturnError_WhenRequestIsInvalid()
        {
            var mealCreateRequest = new MealCreateRequest
            {
                // Intentionally missing required fields
            };

            var (httpResponse, dataResponse) = await app.Client.POSTAsync<MealCreateEndpoint, MealCreateRequest, ErrorResponse>(mealCreateRequest);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            dataResponse.Should().NotBeNull();
            dataResponse.Errors.Should().NotBeNull();
            dataResponse.Errors.ToArray()[0].Value.Should().Contain("AccountID is required");
        }
    }
}