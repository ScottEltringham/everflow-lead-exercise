global using FastEndpoints;
global using FluentValidation;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();

var app = builder.Build();
app.UseFastEndpoints();
//app.MapGet("/", () => "Hello World!");

app.Run();
