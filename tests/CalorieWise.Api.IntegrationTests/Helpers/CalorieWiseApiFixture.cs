using CalorieWise.Api.Data;
using FastEndpoints.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CalorieWise.Api.IntegrationTests.Helpers
{
    public class CalorieWiseApiFixture : AppFixture<Program>
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            // remove the real db context configuration
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CalorieWiseDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            //add a test db context
            services.AddDbContext<CalorieWiseDbContext>(o => o.UseInMemoryDatabase("TestDB"));
        }
    }
}
