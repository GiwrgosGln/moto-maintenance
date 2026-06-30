using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Models.DeleteModel;

public sealed class DeleteModelHandler(MotoDbContext db)
    : IRequestHandler<DeleteModelCommand>
{
    public async Task Handle(DeleteModelCommand request, CancellationToken cancellationToken)
    {
        var entity = await db.Models
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Model", request.Id);

            db.Models.Remove(entity);
            await db.SaveChangesAsync(cancellationToken);
    }
}