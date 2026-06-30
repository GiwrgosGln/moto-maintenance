using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Models.UpdateModel;

public sealed class UpdateModelHandler(MotoDbContext db)
    : IRequestHandler<UpdateModelCommand, ModelDto>
{
    public async Task<ModelDto> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
    {
        var normalized = request.Name.Trim();

        var entity = await db.Models
            .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

        if (entity is null)
            throw new NotFoundException("Models", request.Id);

        var nameTaken = await db.Models
            .AsNoTracking()
            .AnyAsync(m => m.Id != request.Id && m.Name == normalized, cancellationToken);

        if (nameTaken)
            throw new ConflictException($"Model '{normalized}' already exists.");

        entity.Name = normalized;

        await db.SaveChangesAsync(cancellationToken);

        return new ModelDto(entity.Id, entity.Name, entity.ManufacturerId, entity.CreatedAt);
    }
}