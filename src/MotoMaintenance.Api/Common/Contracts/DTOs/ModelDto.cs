namespace MotoMaintenance.Api.Common.Contracts.DTOs;

public sealed record ModelDto(
    Guid Id,
    string Name,
    Guid ManufacturerId,
    DateTimeOffset CreatedAt);