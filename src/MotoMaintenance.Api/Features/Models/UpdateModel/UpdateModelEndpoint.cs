namespace MotoMaintenance.Api.Features.Models.UpdateModel;

public sealed class UpdateModelEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/models")
            .WithTags("Models");

        group.MapPut("/{id:guid}", async (
            Guid id,
            UpdateModelRequest request,
            ISender sender,
            CancellationToken ct) =>
        {
            var model = await sender.Send(request.ToCommand(id), ct);
            return Results.Ok(model);
        });

        return app;
    }
}