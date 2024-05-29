using CalorieWise.Api.Common.Authentication;
using CalorieWise.Api.Data;
using CalorieWise.Api.IntegrationTests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieWise.Api.IntegrationTests.Features.Meal.Delete
{
    public class Sut : BaseSut
    {
        protected override async Task SetupAsync()
        {
            var context = _serviceProvider.GetRequiredService<CalorieWiseDbContext>();
            await context.Database.EnsureCreatedAsync();

            context.Accounts.Add(new Data.Models.Account()
            {
                FirstName = "Test",
                LastName = "User",
                Username = "TestUser",
                Password = PasswordHelper.HashPassword("SuperSecretPassword123!")
            });
            context.Meals.Add(new Data.Models.Meal()
            {
                AccountId = new Data.Models.AccountId(1L),
                MealName = "Test",
                MealDescription = "Test",
                MealDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Calories = 200
            });
            await context.SaveChangesAsync();

            var jwtToken = _serviceProvider.GetRequiredService<IJWTTokenGenerator>();
            var bearerToken = jwtToken.GenerateToken("TestUser");

            Client = CreateClient(c => c.DefaultRequestHeaders.Authorization = new("Bearer", bearerToken));
        }
    }
}
