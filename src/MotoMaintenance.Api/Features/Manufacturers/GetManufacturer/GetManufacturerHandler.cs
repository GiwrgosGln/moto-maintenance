using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Manufacturers.GetManufacturer;

public sealed class GetManufacturerHandler(MotoDbContext db) : IRequestHandler<GetManufacturerQuery, ManufacturerDto>
{
    public async Task<ManufacturerDto> Handle(GetManufacturerQuery request, CancellationToken cancellationToken)
    {
        var manufacturer = await db.Manufacturers
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .Select(m => new ManufacturerDto(m.Id, m.Name, m.CreatedAt))
            .FirstOrDefaultAsync(cancellationToken);

        if (manufacturer is null)
            throw new NotFoundException("Manufacturer", request.Id);

        return manufacturer;
    }
}
