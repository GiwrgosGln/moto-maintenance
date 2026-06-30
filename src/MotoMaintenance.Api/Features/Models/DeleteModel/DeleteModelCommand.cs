namespace MotoMaintenance.Api.Features.Models.DeleteModel;

public sealed record DeleteModelCommand(Guid Id) : IRequest;