using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Manufacturers.DeleteManufacturer;

public sealed class DeleteManufacturerHandler(MotoDbContext db)
    : IRequestHandler<DeleteManufacturerCommand>
{
    public async Task Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
    {
        var entity = await db.Manufacturers
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Manufacturer", request.Id);

        db.Manufacturers.Remove(entity);
        await db.SaveChangesAsync(cancellationToken);
    }
}