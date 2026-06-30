using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Motorcycles.GetUserMotorcycles;

public sealed class GetUserMotorcyclesHandler(MotoDbContext db)
    : IRequestHandler<GetUserMotorcyclesQuery, List<MotorcycleDto>>
{
    public async Task<List<MotorcycleDto>> Handle(GetUserMotorcyclesQuery request, CancellationToken cancellationToken)
    {
        var motorcycles = await db.Motorcycles
            .AsNoTracking()
            .Where(m => m.UserId == request.UserId)
            .Select(m => new MotorcycleDto(
                m.Id,
                m.UserId,
                m.ModelYear,
                m.Nickname,
                m.Color,
                m.CreatedAt,
                m.UpdatedAt,
                m.CreatedBy,
                new ManufacturerSummaryDto(m.Manufacturer.Id, m.Manufacturer.Name),
                new ModelSummaryDto(m.Model.Id, m.Model.Name)))
            .ToListAsync(cancellationToken);

        return motorcycles;
    }
}
