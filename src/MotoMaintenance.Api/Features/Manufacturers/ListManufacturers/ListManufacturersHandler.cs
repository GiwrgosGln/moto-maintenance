using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Manufacturers.ListManufacturers;

public sealed class ListManufacturersHandler(MotoDbContext db)
    : IRequestHandler<ListManufacturersQuery, PagedResult<ManufacturerDto>>
{
    public async Task<PagedResult<ManufacturerDto>> Handle(
        ListManufacturersQuery request, CancellationToken cancellationToken)
    {
        var query = db.Manufacturers.AsNoTracking();

        query = (request.SortBy?.ToLowerInvariant()) switch
        {
            "name"      => request.Descending ? query.OrderByDescending(m => m.Name)      : query.OrderBy(m => m.Name),
            "createdat" => request.Descending ? query.OrderByDescending(m => m.CreatedAt) : query.OrderBy(m => m.CreatedAt),
            _           => query.OrderBy(m => m.Name)
        };

        var total = await query.CountAsync(cancellationToken);

        var items = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(m => new ManufacturerDto(m.Id, m.Name, m.CreatedAt))
            .ToListAsync(cancellationToken);

        return new PagedResult<ManufacturerDto>(items, total, request.Page, request.PageSize);
    }
}