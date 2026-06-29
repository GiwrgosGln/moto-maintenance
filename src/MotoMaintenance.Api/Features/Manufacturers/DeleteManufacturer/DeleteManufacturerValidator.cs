using FluentValidation;

namespace MotoMaintenance.Api.Features.Manufacturers.DeleteManufacturer;

public sealed class DeleteManufacturerValidator : AbstractValidator<DeleteManufacturerCommand>
{
    public DeleteManufacturerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}