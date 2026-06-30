using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Motorcycles.GetUserMotorcycles;

public sealed record GetUserMotorcyclesQuery(Guid UserId) : IRequest<List<MotorcycleDto>>;
