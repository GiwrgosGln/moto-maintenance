using MotoMaintenance.Api.Common.Contracts.DTOs;

namespace MotoMaintenance.Api.Features.Manufacturers.GetManufacturer;

public sealed record GetManufacturerQuery(Guid Id) : IRequest<ManufacturerDto>;
