using MotoMaintenance.Api.Common.Contracts;
using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Models.ListModels;

public sealed record ListModelsQuery(
    int Page = 1,
    int PageSize = 10,
    string? SortBy = null,
    bool Descending = false,
    Guid? ManufacturerId = null)
    : IRequest<PagedResult<ModelDto>>, IPageRequest;