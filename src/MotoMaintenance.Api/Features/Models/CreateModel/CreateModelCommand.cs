namespace MotoMaintenance.Api.Features.Models.CreateModel;

public sealed record CreateModelCommand(string Name, Guid ManufacturerId) : IRequest<Guid>;