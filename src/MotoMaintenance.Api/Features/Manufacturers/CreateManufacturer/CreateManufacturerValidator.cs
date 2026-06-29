using FluentValidation;

namespace MotoMaintenance.Api.Features.Manufacturers.CreateManufacturer;

public sealed class CreateManufacturerValidator : AbstractValidator<CreateManufacturerCommand>
{
    public CreateManufacturerValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}
