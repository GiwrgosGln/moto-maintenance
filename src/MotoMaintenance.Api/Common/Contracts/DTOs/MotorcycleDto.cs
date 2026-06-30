namespace MotoMaintenance.Api.Common.Contracts.DTOs;

public sealed record MotorcycleDto(
    Guid Id,
    Guid UserId,
    string ModelYear,
    string Nickname,
    string Color,
    DateTimeOffset CreatedAt,
    DateTimeOffset? UpdatedAt,
    string? CreatedBy,
    ManufacturerSummaryDto Manufacturer,
    ModelSummaryDto Model);