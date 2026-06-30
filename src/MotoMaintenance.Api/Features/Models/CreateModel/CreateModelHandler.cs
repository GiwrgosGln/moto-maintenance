using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Features.Models.CreateModel;

public sealed class CreateModelHandler(MotoDbContext db) : IRequestHandler<CreateModelCommand, Guid>
{
    public async Task<Guid> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var normalized = request.Name.Trim();

        var manufacturerExists = await db.Manufacturers
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.ManufacturerId, cancellationToken);

        if (!manufacturerExists)
            throw new NotFoundException(nameof(Manufacturer), request.ManufacturerId);


        var exists = await db.Models
            .AsNoTracking()
            .AnyAsync(m => m.Name == normalized, cancellationToken);

        if (exists)
            throw new ConflictException($"Model '{normalized}' already exists.");

        var entity = new Model 
        {
            Name= normalized,
            ManufacturerId = request.ManufacturerId
        };

        db.Models.Add(entity);
        await db.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}