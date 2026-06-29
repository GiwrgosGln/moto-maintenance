namespace MotoMaintenance.Api.Common.Contracts.DTOs;

public sealed record ManufacturerDto(Guid Id, string Name, DateTimeOffset CreatedAt);