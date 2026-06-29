using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Models.GetModel;

public sealed record GetModelQuery(Guid Id) : IRequest<ModelDto>;