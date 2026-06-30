using FluentValidation;

namespace MotoMaintenance.Api.Features.Motorcycles.UpdateMotorcycle;

public sealed class UpdateMotorcycleValidator : AbstractValidator<UpdateMotorcycleCommand>
{
    public UpdateMotorcycleValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.ModelYear)
            .NotEmpty()
            .When(x => x.ModelYear is not null);
        RuleFor(x => x.Nickname)
            .NotEmpty()
            .When(x => x.Nickname is not null);
        RuleFor(x => x.Color)
            .NotEmpty()
            .When(x => x.Color is not null);
    }
}