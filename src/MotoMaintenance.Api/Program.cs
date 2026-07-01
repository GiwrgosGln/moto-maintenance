using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Extensions;
using MotoMaintenance.Api.Common.Middleware;
using MotoMaintenance.Api.Database;
using Scalar.AspNetCore;
using MotoMaintenance.Api.Common.Converters;
using Auth0.AspNetCore.Authentication.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuth0ApiAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"]!;
    options.Audience = builder.Configuration["Auth0:Audience"]!;
});

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.SnakeCaseLower;
    options.SerializerOptions.Converters.Add(new EmptyStringGuidConverter());
});

// Infrastructure
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddOpenApi();

var app = builder.Build();

// Pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.Services.ApplyMigrations();
}

app.MapEndpointsFromAssembly();

app.Run();