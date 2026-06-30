using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Motorcycles.DeleteMotorcycle;

public sealed class DeleteMotorcycleHandler(MotoDbContext db)
    : IRequestHandler<DeleteMotorcycleCommand>
{
    public async Task Handle(DeleteMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var entity = await db.Motorcycles
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Motorcycle", request.Id);

        db.Motorcycles.Remove(entity);
        await db.SaveChangesAsync(cancellationToken);
    }
}