using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Models.UpdateModel;

public sealed record UpdateModelCommand(Guid Id, string Name) : IRequest<ModelDto>;