namespace MotoMaintenance.Api.Features.Models.CreateModel;

public sealed class CreateModelEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/models")
            .WithTags("Models");

        group.MapPost("/", async (
            CreateModelRequest request,
            ISender sender,
            CancellationToken ct) =>
        {
            var id = await sender.Send(request.ToCommand(), ct);
            return Results.Created($"/api/v1/models/{id}", new CreateModelResponse(id, request.Name, request.ManufacturerId));
        });

        return app;
    }
}
