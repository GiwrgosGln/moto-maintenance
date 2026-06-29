namespace MotoMaintenance.Api.Features.Models.GetModel;

public sealed class GetModelEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/models")
            .WithTags("Models");

        group.MapGet("/{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
        {
            var model = await sender.Send(new GetModelQuery(id), ct);
            return Results.Ok(model);
        });

        return app;
    }
}