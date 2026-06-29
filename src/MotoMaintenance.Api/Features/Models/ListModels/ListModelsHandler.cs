using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Models.ListModels;

public sealed class ListModelsHandler(MotoDbContext db)
    : IRequestHandler<ListModelsQuery, PagedResult<ModelDto>>
{
    public async Task<PagedResult<ModelDto>> Handle(
        ListModelsQuery request, CancellationToken cancellationToken)
    {
        var query = db.Models.AsNoTracking();

        if (request.ManufacturerId is { } mid)
            query = query.Where(m => m.ManufacturerId == mid);

        query = (request.SortBy?.ToLowerInvariant()) switch
        {
            "name"           => request.Descending ? query.OrderByDescending(m => m.Name)           : query.OrderBy(m => m.Name),
            "createdat"      => request.Descending ? query.OrderByDescending(m => m.CreatedAt)      : query.OrderBy(m => m.CreatedAt),
            "manufacturerid" => request.Descending ? query.OrderByDescending(m => m.ManufacturerId) : query.OrderBy(m => m.ManufacturerId),
            _                => query.OrderBy(m => m.Name)
        };

        var total = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(m => new ModelDto(m.Id, m.Name, m.ManufacturerId, m.CreatedAt))
            .ToListAsync(cancellationToken);

        return new PagedResult<ModelDto>(items, total, request.Page, request.PageSize);
    }
}