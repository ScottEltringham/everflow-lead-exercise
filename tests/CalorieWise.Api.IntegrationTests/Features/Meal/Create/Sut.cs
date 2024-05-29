using CalorieWise.Api.Common.Authentication;
using CalorieWise.Api.Data;
using CalorieWise.Api.IntegrationTests.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieWise.Api.IntegrationTests.Features.Meal.Create
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
            await context.SaveChangesAsync();

            var jwtToken = _serviceProvider.GetRequiredService<IJWTTokenGenerator>();
            var bearerToken = jwtToken.GenerateToken("TestUser");

            Client = CreateClient(c => c.DefaultRequestHeaders.Authorization = new("Bearer", bearerToken));
        }
    }
}
