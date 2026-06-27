using MotoMaintenance.Api.Common.Contracts;

namespace MotoMaintenance.Api.Common.Extensions;

public static class EndpointExtensions
{
    public static IEndpointRouteBuilder MapEndpointsFromAssembly(this IEndpointRouteBuilder app)
    {
        var modules = typeof(EndpointExtensions).Assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false }
                        && typeof(IModule).IsAssignableFrom(t))
            .Select(Activator.CreateInstance)
            .Cast<IModule>();

        foreach (var module in modules)
            module.MapEndpoints(app);

        return app;
    }
}