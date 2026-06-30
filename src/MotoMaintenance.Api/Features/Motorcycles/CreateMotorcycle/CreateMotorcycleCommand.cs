namespace MotoMaintenance.Api.Features.Motorcycles.CreateMotorcycle;

public sealed record CreateMotorcycleCommand(
    string ModelYear,
    string Nickname,
    string Color,
    Guid ManufacturerId,
    Guid ModelId
) : IRequest<Guid>;