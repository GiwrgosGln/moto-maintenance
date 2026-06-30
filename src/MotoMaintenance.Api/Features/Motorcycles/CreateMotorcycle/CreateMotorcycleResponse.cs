namespace MotoMaintenance.Api.Features.Motorcycles.CreateMotorcycle;

public sealed record CreateMotorcycleResponse(
    Guid Id,
    string ModelYear,
    string Nickname,
    string Color,
    Guid ManufacturerId,
    Guid ModelId
);