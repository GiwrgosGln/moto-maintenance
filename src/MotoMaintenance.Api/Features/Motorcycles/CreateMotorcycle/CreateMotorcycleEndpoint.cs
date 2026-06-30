namespace MotoMaintenance.Api.Features.Motorcycles.CreateMotorcycle;

public sealed class CreateMotorcycleEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/motorcycles")
            .WithTags("Motorcycles");

        group.MapPost("/", async (
            CreateMotorcycleRequest request,
            ISender sender,
            CancellationToken ct) =>
        {
            var id = await sender.Send(request.ToCommand(), ct);
            return Results.Created($"/api/v1/motorcycles/{id}", new CreateMotorcycleResponse(id, request.ModelYear, request.Nickname, request.Color, request.ManufacturerId, request.ModelId));
        });

        return app;
    }
}