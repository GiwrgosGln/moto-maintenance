namespace MotoMaintenance.Api.Features.Manufacturers.DeleteManufacturer;

public sealed class DeleteManufacturerEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/manufacturers")
            .WithTags("Manufacturers");

        group.MapDelete("/{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
        {
            await sender.Send(new DeleteManufacturerCommand(id), ct);
            return Results.NoContent();
        });

        return app;
    }
}