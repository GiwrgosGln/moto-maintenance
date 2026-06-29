namespace MotoMaintenance.Api.Features.Manufacturers.ListManufacturers;

public sealed class ListManufacturersEndpoint : IModule
{
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/v1/manufacturers")
            .WithTags("Manufacturers");

        group.MapGet("/", async (
            [AsParameters] ListManufacturersQuery query,
            ISender sender,
            CancellationToken ct) =>
        {
            var result = await sender.Send(query, ct);
            return Results.Ok(result);
        });

        return app;
    }
}