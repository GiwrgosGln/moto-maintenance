using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Manufacturers.ListManufacturers;

public sealed record ListManufacturersQuery(
    int Page = 1,
    int PageSize = 10,
    string? SortBy = null,
    bool Descending = false)
    : IRequest<PagedResult<ManufacturerDto>>, IPageRequest;