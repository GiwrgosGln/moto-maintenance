using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Features.Manufacturers.CreateManufacturer;

public sealed class CreateManufacturerHandler(MotoDbContext db) : IRequestHandler<CreateManufacturerCommand, Guid>
{
    public async Task<Guid> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
    {
        var normalized = request.Name.Trim();

        var exists = await db.Manufacturers
            .AsNoTracking()
            .AnyAsync(m => m.Name == normalized, cancellationToken);

        if (exists)
            throw new ConflictException($"Manufacturer '{normalized}' already exists.");

        var entity = new Manufacturer { Name = normalized };

        db.Manufacturers.Add(entity);
        await db.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
