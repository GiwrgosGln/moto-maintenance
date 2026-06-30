namespace MotoMaintenance.Api.Features.Motorcycles.DeleteMotorcycle;

public sealed record DeleteMotorcycleCommand(Guid Id): IRequest;