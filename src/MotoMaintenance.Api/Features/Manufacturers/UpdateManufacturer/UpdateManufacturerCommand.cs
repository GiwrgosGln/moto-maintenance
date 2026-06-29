using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Manufacturers.UpdateManufacturer;

public sealed record UpdateManufacturerCommand(Guid Id, string Name) : IRequest<ManufacturerDto>;