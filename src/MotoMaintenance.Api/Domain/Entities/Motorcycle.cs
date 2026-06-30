using MotoMaintenance.Api.Domain.Entities.Common;

namespace MotoMaintenance.Api.Domain.Entities;

public sealed class Motorcycle : AuditableEntity
{
    //TODO: Add user
    public required Guid ManufacturerId { get; set; }
    public required Guid ModelId { get; set; }
    public required Guid UserId { get; set; }
    public required string ModelYear { get; set; }
    public required string Nickname { get; set; }
    public required string Color { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;
    public Model Model { get; set; } = null!;
}