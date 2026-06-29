namespace MotoMaintenance.Api.Features.Manufacturers.DeleteManufacturer;

public sealed record DeleteManufacturerCommand(Guid Id) : IRequest;