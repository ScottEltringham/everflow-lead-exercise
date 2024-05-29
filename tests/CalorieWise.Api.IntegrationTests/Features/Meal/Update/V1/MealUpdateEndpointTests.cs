using CalorieWise.Api.Features.Meal.ReadAll.V1;
using CalorieWise.Api.Features.Meal.Update.V1;
using FastEndpoints;
using FastEndpoints.Testing;
using FluentAssertions;
using System.Net;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Features.Meal.Update.V1
{
    public class MealUpdateEndpointTests(Sut app) : TestBase<Sut>
    {
        [Fact]
        public async Task MealUpdateEndpoint_ShouldUpdateMeal_WhenRequestIsValid()
        {
            var mealUpdateRequest = new MealUpdateRequest
            {
                MealID = 1L,
                MealName = "Updated Test Meal",
                MealDescription = "An updated description",
                Calories = 600,
                MealDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1))
            };

            var (httpResponse, dataResponse) = await app.Client.PUTAsync<MealUpdateEndpoint, MealUpdateRequest, MealUpdateResponse>(mealUpdateRequest);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            dataResponse.Should().NotBeNull();
            dataResponse.MealName.Should().Be(mealUpdateRequest.MealName);
            dataResponse.MealDescription.Should().Be(mealUpdateRequest.MealDescription);
            dataResponse.Calories.Should().Be(mealUpdateRequest.Calories);
            dataResponse.MealDate.Should().Be(mealUpdateRequest.MealDate);
        }

        [Fact]
        public async Task MealUpdateEndpoint_ShouldReturnError_WhenRequestIsInvalid()
        {
            var mealUpdateRequest = new MealUpdateRequest
            {
                MealID = 99L,
                MealName = "Updated Test Meal",
                MealDescription = "An updated description",
                Calories = 600,
                MealDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1))
            };

            var (httpResponse, dataResponse) = await app.Client.PUTAsync<MealUpdateEndpoint, MealUpdateRequest, ProblemDetails>(mealUpdateRequest);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            dataResponse.Should().NotBeNull();
            dataResponse.Errors.ToArray()[0].Reason.Should().Contain("Supplied MealId does not return a matching database record");
        }
    }
}
