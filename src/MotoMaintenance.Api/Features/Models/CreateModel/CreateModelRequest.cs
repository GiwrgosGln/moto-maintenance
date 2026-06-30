namespace MotoMaintenance.Api.Features.Models.CreateModel;

public sealed record CreateModelRequest(string Name, Guid ManufacturerId)
{
    public CreateModelCommand ToCommand() => new(Name, ManufacturerId);
}
