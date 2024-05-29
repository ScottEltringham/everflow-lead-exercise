using CalorieWise.Api.Common.Authentication;
using CalorieWise.Api.Data;
using FastEndpoints.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieWise.Api.IntegrationTests.Helpers
{
    [DisableWafCache]
    public class CalorieWiseApiFixture : AppFixture<Program>
    {
        private readonly string _connectionString = "server=localhost;Database=CalorieWise.IntegrationTests;Trusted_Connection=True;TrustServerCertificate=True;";
        private IServiceProvider _serviceProvider;

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

        protected override void ConfigureServices(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CalorieWiseDbContext>));
            if (descriptor != null)
            {
                services.Remove(descriptor);

                services.AddDbContext<CalorieWiseDbContext>(
                o =>
                {
                    o.UseSqlServer(_connectionString,
                        sqlOptions =>
                        {
                            sqlOptions.CommandTimeout(45);
                            sqlOptions.EnableRetryOnFailure(
                                maxRetryCount: 10,
                                maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorNumbersToAdd: null);
                            sqlOptions.MigrationsAssembly("CalorieWise.Api");
                        });
                });
            }
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override async Task TearDownAsync()
        {
            using var context = _serviceProvider.GetRequiredService<CalorieWiseDbContext>();
            await context.Database.EnsureDeletedAsync();
        }
    }

}
