namespace MotoMaintenance.Api.Features.Models.CreateModel;

public sealed record CreateModelResponse(Guid Id, string Name, Guid ManufacturerId);
