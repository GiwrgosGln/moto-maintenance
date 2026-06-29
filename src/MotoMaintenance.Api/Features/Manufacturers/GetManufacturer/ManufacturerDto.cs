namespace MotoMaintenance.Api.Features.Manufacturers.GetManufacturer;

public sealed record ManufacturerDto(Guid Id, string Name, DateTimeOffset CreatedAt);
