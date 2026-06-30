using FluentValidation;

namespace MotoMaintenance.Api.Features.Models.CreateModel;

public sealed class CreateModelValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelValidator()
    {   
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.ManufacturerId)
            .NotEmpty();
    }
}