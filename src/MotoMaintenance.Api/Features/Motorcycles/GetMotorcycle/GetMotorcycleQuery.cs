using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Motorcycles.GetMotorcycle;

public sealed record GetMotorcycleQuery(Guid Id) : IRequest<MotorcycleDto>;