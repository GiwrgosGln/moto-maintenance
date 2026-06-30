using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Motorcycles.GetMotorcycle;

public sealed class GetMotorcycleHandler(MotoDbContext db)
    : IRequestHandler<GetMotorcycleQuery, MotorcycleDto>
{
    public async Task<MotorcycleDto> Handle(GetMotorcycleQuery request, CancellationToken cancellationToken)
    {
        var motorcycle = await db.Motorcycles
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
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
            .FirstOrDefaultAsync(cancellationToken);

        if (motorcycle is null)
            throw new NotFoundException("Motorcycle", request.Id);

        return motorcycle;
    }
}
