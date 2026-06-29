using MotoMaintenance.Api.Domain.Entities.Common;

namespace MotoMaintenance.Api.Domain.Entities;

public sealed class Model : AuditableEntity
{
    public required string Name { get; set; }

    public Guid ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;
}