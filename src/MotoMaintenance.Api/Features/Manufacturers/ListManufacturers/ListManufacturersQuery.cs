using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Manufacturers.ListManufacturers;

public sealed record ListManufacturersQuery(
    int Page,
    int PageSize,
    string? SortBy,
    bool Descending)
    : IRequest<PagedResult<ManufacturerDto>>, IPageRequest;