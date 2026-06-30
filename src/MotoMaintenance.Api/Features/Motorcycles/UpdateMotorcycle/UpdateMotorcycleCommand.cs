using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Motorcycles.UpdateMotorcycle;

public sealed record UpdateMotorcycleCommand(
    Guid Id,
    string? ModelYear,
    string? Nickname,
    string? Color
) : IRequest<MotorcycleDto>;