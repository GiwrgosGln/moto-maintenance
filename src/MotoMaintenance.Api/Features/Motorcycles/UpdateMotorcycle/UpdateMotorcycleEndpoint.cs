namespace MotoMaintenance.Api.Features.Motorcycles.UpdateMotorcycle;

public sealed class UpdateMotorcycleEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/motorcycles")
            .WithTags("Motorcycles");

        group.MapPut("/{id:guid}", async (
            Guid id,
            UpdateMotorcycleRequest request,
            ISender sender,
            CancellationToken ct) =>
        {
            var motorcycle = await sender.Send(request.ToCommand(id), ct);
            return Results.Ok(motorcycle);
        });

        return app;
    }   
}