global using FastEndpoints;
using CalorieWise.Api.Common.Authentication;
using CalorieWise.Api.Common.Processors;
using CalorieWise.Api.Data;
using CalorieWise.Api.Data.Repositories.Implementation;
using CalorieWise.Api.Data.Repositories.Interfaces;
using CalorieWise.Api.Features.Account.Create.V1;
using CalorieWise.Api.Features.Account.Login.V1;
using CalorieWise.Api.Features.Meal.Create.V1;
using CalorieWise.Api.Features.Meal.Delete.V1;
using CalorieWise.Api.Features.Meal.ReadAll.V1;
using CalorieWise.Api.Features.Meal.Update.V1;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CalorieWiseDbContext>(
    o => 
    {
        o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"),
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

// Add Repositories
builder.Services.AddScoped(typeof(ICreateRepository<,>), typeof(CreateRepository<,>));
builder.Services.AddScoped(typeof(IReadRepository<,,>), typeof(ReadRepository<,,>));
builder.Services.AddScoped(typeof(IUpdateRepository<,>), typeof(UpdateRepository<,>));
builder.Services.AddScoped(typeof(IDeleteRepository<,>), typeof(DeleteRepository<,>));

// Add Services
builder.Services.AddScoped<IJWTTokenGenerator, JWTTokenGenerator>();

builder.Services.AddScoped<IAccountCreateService, AccountCreateService>();
builder.Services.AddScoped<IAccountLoginService, AccountLoginService>();

builder.Services.AddScoped<IMealCreateService, MealCreateService>();
builder.Services.AddScoped<IMealReadAllService, MealReadAllService>();
builder.Services.AddScoped<IMealUpdateService, MealUpdateService>();
builder.Services.AddScoped<IMealDeleteService, MealDeleteService>();

builder.Services
    .AddAuthenticationJwtBearer(s => s.SigningKey = builder.Configuration.GetValue<string>("JWTSigningKey"))
    .AddAuthorization()
    .AddFastEndpoints();

builder.Services.SwaggerDocument(o =>
{
    o.MaxEndpointVersion = 1;
    o.DocumentSettings = s =>
    {
        s.DocumentName = "Initial Release";
        s.Title = "CalorieWise.Api";
        s.Version = "v1";
    };
});

var app = builder.Build();

app.UseAuthentication()
    .UseAuthorization()
    .UseFastEndpoints(c => 
    {
        c.Endpoints.RoutePrefix = "api";
        c.Versioning.Prefix = "v";
        c.Versioning.PrependToRoute = true;
        c.Versioning.DefaultVersion = 1;
        c.Endpoints.Configurator = ep =>
        {
            ep.PreProcessor<RequestLogger>(Order.Before);
            ep.PostProcessor<ExceptionProcessor>(Order.Before);
        };
    });

app.UseSwaggerGen();

app.Run();

namespace CalorieWise.Api
{
    public abstract class Program;
}