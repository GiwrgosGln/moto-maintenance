namespace MotoMaintenance.Api.Features.Motorcycles.UpdateMotorcycle;

public sealed record UpdateMotorcycleRequest(
    string? ModelYear = null,
    string? Nickname = null,
    string? Color = null
)
{
    public UpdateMotorcycleCommand ToCommand(Guid id) => new(id, ModelYear, Nickname, Color);
}