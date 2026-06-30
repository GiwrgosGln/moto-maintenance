namespace MotoMaintenance.Api.Features.Motorcycles.DeleteMotorcycle;

public sealed class DeleteMotorcycleEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/motorcycles")
            .WithTags("Motorcycles");

        group.MapDelete("{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
        {
            await sender.Send(new DeleteMotorcycleCommand(id), ct);
            return Results.NoContent();
        });

        return app;
    }
}