using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Features.Motorcycles.UpdateMotorcycle;

public sealed class UpdateMotorcycleHandler(MotoDbContext db)
    : IRequestHandler<UpdateMotorcycleCommand, MotorcycleDto>
{
    public async Task<MotorcycleDto> Handle(
        UpdateMotorcycleCommand request,
        CancellationToken cancellationToken)
    {
        var motorcycle = await db.Motorcycles
            .Include(m => m.Model.Manufacturer)
            .AsTracking()
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (motorcycle is null)
            throw new NotFoundException(nameof(Motorcycle), request.Id);

        motorcycle.ModelYear = request.ModelYear?.Trim() ?? motorcycle.ModelYear;
        motorcycle.Nickname = request.Nickname?.Trim() ?? motorcycle.Nickname;
        motorcycle.Color = request.Color?.Trim() ?? motorcycle.Color;

        await db.SaveChangesAsync(cancellationToken);

        return new MotorcycleDto(
            motorcycle.Id,
            motorcycle.UserId,
            motorcycle.ModelYear,
            motorcycle.Nickname,
            motorcycle.Color,
            motorcycle.CreatedAt,
            motorcycle.UpdatedAt,
            motorcycle.CreatedBy,
            new ManufacturerSummaryDto(
                motorcycle.Model.Manufacturer.Id,
                motorcycle.Model.Manufacturer.Name
            ),
            new ModelSummaryDto(
                motorcycle.Model.Id,
                motorcycle.Model.Name
            )
        );
    }
}