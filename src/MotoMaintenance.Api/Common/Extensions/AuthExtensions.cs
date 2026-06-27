using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MotoMaintenance.Api.Common.Extensions;

public static class AuthExtensions
{
    public static IServiceCollection AddAuth0(this IServiceCollection services, IConfiguration cfg)
    {
        var domain = cfg["Auth0:Domain"]!;
        var audience = cfg["Auth0:Audience"]!;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://{domain}/";
                options.Audience = audience;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    ValidIssuer = $"https://{domain}/",
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.FromSeconds(30)
                };
            });

        services.AddAuthorization();

        return services;
    }
}