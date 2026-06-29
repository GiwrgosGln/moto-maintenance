using FluentValidation;

namespace MotoMaintenance.Api.Features.Manufacturers.UpdateManufacturer;

public sealed class UpdateManufacturerValidator : AbstractValidator<UpdateManufacturerCommand>
{
    public UpdateManufacturerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}