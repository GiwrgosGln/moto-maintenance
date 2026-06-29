namespace MotoMaintenance.Api.Features.Manufacturers.UpdateManufacturer;

public sealed class UpdateManufacturerEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/manufacturers")
            .WithTags("Manufacturers");

        group.MapPut("/{id:guid}", async (
            Guid id,
            UpdateManufacturerRequest request,
            ISender sender,
            CancellationToken ct) =>
        {
            var manufacturer = await sender.Send(request.ToCommand(id), ct);
            return Results.Ok(manufacturer);
        });

        return app;
    }
}