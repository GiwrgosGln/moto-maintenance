using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Extensions;
using MotoMaintenance.Api.Common.Middleware;
using MotoMaintenance.Api.Database;

var builder = WebApplication.CreateBuilder(args);

// Infrastructure
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAuth0(builder.Configuration);
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
    app.Services.ApplyMigrations();
}

app.MapEndpointsFromAssembly();

app.Run();