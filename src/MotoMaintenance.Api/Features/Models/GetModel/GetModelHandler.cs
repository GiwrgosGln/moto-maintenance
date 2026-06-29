using Microsoft.EntityFrameworkCore;
using MotoMaintenance.Api.Common.Contracts.DTOs;
using MotoMaintenance.Api.Common.Exceptions;
using MotoMaintenance.Api.Database;

namespace MotoMaintenance.Api.Features.Models.GetModel;

public sealed class GetModelHandler(MotoDbContext db)
    : IRequestHandler<GetModelQuery, ModelDto>
{
    public async Task<ModelDto> Handle(GetModelQuery request, CancellationToken cancellationToken)
    {
        var model = await db.Models
            .AsNoTracking()
            .Where(m => m.Id == request.Id)
            .Select(m => new ModelDto(m.Id, m.Name, m.ManufacturerId, m.CreatedAt))
            .FirstOrDefaultAsync(cancellationToken);

        if (model is null)
            throw new NotFoundException("Model", request.Id);

        return model;
    }
}