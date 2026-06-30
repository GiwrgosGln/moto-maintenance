namespace MotoMaintenance.Api.Features.Models.UpdateModel;

public sealed record UpdateModelRequest(string Name)
{
    public UpdateModelCommand ToCommand(Guid id) => new(id, Name);
}