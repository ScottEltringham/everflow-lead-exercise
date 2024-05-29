using CalorieWise.Api.Data;
using FastEndpoints.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieWise.Api.IntegrationTests.Helpers
{
    public class BaseSut : AppFixture<Program>
    {
        private readonly string _connectionString = "server=localhost;Database=CalorieWise.IntegrationTests;Trusted_Connection=True;TrustServerCertificate=True;";
        public IServiceProvider _serviceProvider;

        protected override async Task SetupAsync()
        {
            var context = _serviceProvider.GetRequiredService<CalorieWiseDbContext>();
            await context.Database.EnsureCreatedAsync();
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
