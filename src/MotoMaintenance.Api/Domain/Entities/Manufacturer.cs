using MotoMaintenance.Api.Domain.Entities.Common;

namespace MotoMaintenance.Api.Domain.Entities;

public sealed class Manufacturer : AuditableEntity
{
    public required string Name { get; set; }
}
