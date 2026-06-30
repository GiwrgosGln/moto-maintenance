using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Extensions;
using MotoMaintenance.Api.Common.Middleware;
using MotoMaintenance.Api.Database;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.SnakeCaseLower;
    options.SerializerOptions.Converters.Add(new MotoMaintenance.Api.Common.Converters.EmptyStringGuidConverter());
});

// Infrastructure
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAuth0(builder.Configuration);
builder.Services.AddAuthorization();
builder.Services.AddOpenApi();

var app = builder.Build();

// Pipeline
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.Services.ApplyMigrations();
}

app.MapEndpointsFromAssembly();

app.Run();