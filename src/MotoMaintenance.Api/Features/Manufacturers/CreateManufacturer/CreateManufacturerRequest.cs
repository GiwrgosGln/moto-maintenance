namespace MotoMaintenance.Api.Features.Manufacturers.CreateManufacturer;

public sealed record CreateManufacturerRequest(string Name)
{
    public CreateManufacturerCommand ToCommand() => new(Name);
}
