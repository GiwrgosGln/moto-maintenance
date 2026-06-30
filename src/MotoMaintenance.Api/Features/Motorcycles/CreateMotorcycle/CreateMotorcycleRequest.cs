namespace MotoMaintenance.Api.Features.Motorcycles.CreateMotorcycle;

public sealed record CreateMotorcycleRequest(
    string ModelYear,
    string Nickname,
    string Color,
    Guid ManufacturerId,
    Guid ModelId
)
{
    public CreateMotorcycleCommand ToCommand() =>
        new(ModelYear, Nickname, Color, ManufacturerId, ModelId);
}