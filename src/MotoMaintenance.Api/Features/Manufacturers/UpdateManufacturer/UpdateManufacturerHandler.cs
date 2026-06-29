using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Manufacturers.UpdateManufacturer;

public sealed class UpdateManufacturerHandler(MotoDbContext db)
    : IRequestHandler<UpdateManufacturerCommand, ManufacturerDto>
{
    public async Task<ManufacturerDto> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var normalized = request.Name.Trim();

        var entity = await db.Manufacturers
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Manufacturer", request.Id);

        var nameTaken = await db.Manufacturers
            .AsNoTracking()
            .AnyAsync(m => m.Id != request.Id && m.Name == normalized, cancellationToken);

        if (nameTaken)
            throw new ConflictException($"Manufacturer '{normalized}' already exists.");

        entity.Name = normalized;

        await db.SaveChangesAsync(cancellationToken);

        return new ManufacturerDto(entity.Id, entity.Name, entity.CreatedAt);
    }
}