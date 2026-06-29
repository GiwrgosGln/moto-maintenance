namespace MotoMaintenance.Api.Features.Manufacturers.CreateManufacturer;

public sealed class CreateManufacturerEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/manufacturers")
            .WithTags("Manufacturers");

        group.MapPost("/", async (
            CreateManufacturerRequest request,
            ISender sender,
            CancellationToken ct) =>
        {
            var id = await sender.Send(request.ToCommand(), ct);
            return Results.Created($"/api/v1/manufacturers/{id}", new CreateManufacturerResponse(id, request.Name));
        });

        return app;
    }
}
