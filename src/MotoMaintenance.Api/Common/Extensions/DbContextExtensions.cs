using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MotoMaintenance.Api.Common.Interceptors;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Common.Extensions;

public static class DbContextExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration cfg)
    {
        services.AddSingleton<AuditableEntityInterceptor>();

        services.AddDbContext<MotoDbContext>((sp, opts) =>
        {
            opts.UseSqlServer(cfg.GetConnectionString("MotoDb"), sql => sql.MigrationsAssembly("MotoMaintenance.Api"));
            opts.UseSnakeCaseNamingConvention();
            opts.AddInterceptors(sp.GetRequiredService<AuditableEntityInterceptor>());
        });

        return services;
    }

    public static void ApplyMigrations(this IServiceProvider app)
    {
        using var scope = app.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<MotoDbContext>();
        db.Database.Migrate();
    }
}