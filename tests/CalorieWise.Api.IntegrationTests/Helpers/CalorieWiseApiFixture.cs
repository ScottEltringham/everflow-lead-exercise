using CalorieWise.Api.Data;
using FastEndpoints.Testing;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace CalorieWise.Api.IntegrationTests.Helpers
{
    public class CalorieWiseApiFixture : AppFixture<Program>
    {
        private readonly string _connectionString = "server=localhost;Database=CalorieWise.IntegrationTests;Trusted_Connection=True;TrustServerCertificate=True;";
        private IServiceProvider _serviceProvider;


        protected override void ConfigureServices(IServiceCollection services)
        {
            // remove the real db context configuration
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CalorieWiseDbContext>));
            if (descriptor != null)
                services.Remove(descriptor);

            //add a test db context
            //services.AddDbContext<CalorieWiseDbContext>(o => o.UseInMemoryDatabase("TestDB"));

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


            _serviceProvider = services.BuildServiceProvider();
        }

        protected override async Task TearDownAsync()
        {
            using var context = _serviceProvider.GetRequiredService<CalorieWiseDbContext>();
            await context.Database.EnsureDeletedAsync();
        }
    }

}
