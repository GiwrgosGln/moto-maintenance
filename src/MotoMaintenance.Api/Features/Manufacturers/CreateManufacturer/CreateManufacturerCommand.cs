namespace MotoMaintenance.Api.Features.Manufacturers.CreateManufacturer;

public sealed record CreateManufacturerCommand(string Name) : IRequest<Guid>;
