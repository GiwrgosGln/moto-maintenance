namespace MotoMaintenance.Api.Features.Motorcycles.GetMotorcycle;

public sealed class GetMotorcycleEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/motorcycles")
            .WithTags("Motorcycles");

        group.MapGet("/{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
        {
            var motorcycle = await sender.Send(new GetMotorcycleQuery(id), ct);
            return Results.Ok(motorcycle);
        });

        return app;
    }
}
