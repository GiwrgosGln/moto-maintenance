using MotoMaintenance.Api.Domain.Entities.Common;

namespace MotoMaintenance.Api.Domain.Entities;

public sealed class User : AuditableEntity
{
    public required Guid UserId { get; set; }
    public required string Auth0Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required bool IsProfilePublic { get; set; }

}