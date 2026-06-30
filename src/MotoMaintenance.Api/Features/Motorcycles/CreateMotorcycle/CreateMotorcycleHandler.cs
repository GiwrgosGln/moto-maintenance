using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;
using MotoMaintenance.Api.Domain.Entities;

namespace MotoMaintenance.Api.Features.Motorcycles.CreateMotorcycle;

public sealed class CreateMotorcycleHandler(MotoDbContext db) : IRequestHandler<CreateMotorcycleCommand, Guid>
{
    public async Task<Guid> Handle(CreateMotorcycleCommand request, CancellationToken cancellationToken)
    {
        var normalizedModelYear = request.ModelYear.Trim();
        var normalizedNickname = request.Nickname.Trim();
        var normalizedColor = request.Color.Trim();

        var manufacturerExists = await db.Manufacturers
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.ManufacturerId, cancellationToken);

        if (!manufacturerExists)
            throw new NotFoundException(nameof(Manufacturer), request.ManufacturerId);

        var modelExists = await db.Models
            .AsNoTracking()
            .AnyAsync(x => x.Id == request.ModelId, cancellationToken);

        if (!modelExists)
            throw new NotFoundException(nameof(Model), request.ModelId);

        var exists = await db.Motorcycles
            .AsNoTracking()
            .AnyAsync(x => x.ModelYear == normalizedModelYear && x.Nickname == normalizedNickname && x.Color == normalizedColor, cancellationToken);

        if (exists)
            throw new ConflictException($"Motorcycle '{normalizedModelYear} {normalizedNickname} {normalizedColor}' already exists.");

        var entity = new Motorcycle
        {
            UserId = Guid.Parse("472546dd-66c6-4df2-9185-955269b66e96"), // TODO: Get user id from token
            ModelYear = normalizedModelYear,
            Nickname = normalizedNickname,
            Color = normalizedColor,
            ManufacturerId = request.ManufacturerId,
            ModelId = request.ModelId
        };

        db.Motorcycles.Add(entity);
        await db.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}