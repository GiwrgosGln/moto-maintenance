namespace MotoMaintenance.Api.Features.Manufacturers.UpdateManufacturer;

public sealed record UpdateManufacturerRequest(string Name)
{
    public UpdateManufacturerCommand ToCommand(Guid id) => new(id, Name);
}