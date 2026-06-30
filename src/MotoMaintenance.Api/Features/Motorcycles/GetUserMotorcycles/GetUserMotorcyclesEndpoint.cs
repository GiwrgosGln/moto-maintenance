namespace MotoMaintenance.Api.Features.Motorcycles.GetUserMotorcycles;

public sealed class GetUserMotorcyclesEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/motorcycles")
            .WithTags("Motorcycles");

        group.MapGet("/user/{userId:guid}", async (
            Guid userId,
            ISender sender,
            CancellationToken ct) =>
        {
            var motorcycles = await sender.Send(new GetUserMotorcyclesQuery(userId), ct);
            return Results.Ok(motorcycles);
        });

        return app;
    }
}
