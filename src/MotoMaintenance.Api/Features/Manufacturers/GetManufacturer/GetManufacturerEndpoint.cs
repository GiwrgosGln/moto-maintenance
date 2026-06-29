namespace MotoMaintenance.Api.Features.Manufacturers.GetManufacturer;

public sealed class GetManufacturerEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/manufacturers")
            .WithTags("Manufacturers");

        group.MapGet("/{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
        {
            var manufacturer = await sender.Send(new GetManufacturerQuery(id), ct);
            return Results.Ok(manufacturer);
        });

        return app;
    }
}