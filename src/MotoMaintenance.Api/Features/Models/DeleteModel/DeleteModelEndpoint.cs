namespace MotoMaintenance.Api.Features.Models.DeleteModel;

public sealed class DeleteModelEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/models")
            .WithTags("Models");
        
        group.MapDelete("{id:guid}", async (
            Guid id,
            ISender sender,
            CancellationToken ct) =>
        {
            await sender.Send(new DeleteModelCommand(id), ct);
            return Results.NoContent();
        });

        return app;   
    }
}