namespace MotoMaintenance.Api.Features.Models.ListModels;

public sealed class ListModelsEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/models")
            .WithTags("Models");

        group.MapGet("/", async (
            [AsParameters] ListModelsQuery query,
            ISender sender,
            CancellationToken ct) =>
        {
            var result = await sender.Send(query, ct);
            return Results.Ok(result);
        });

        return app;
    }
}