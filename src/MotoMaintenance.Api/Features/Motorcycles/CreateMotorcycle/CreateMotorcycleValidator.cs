using FluentValidation;

namespace MotoMaintenance.Api.Features.Motorcycles.CreateMotorcycle;

public sealed class CreateMotorcycleValidator : AbstractValidator<CreateMotorcycleCommand>
{
    public CreateMotorcycleValidator()
    {
        RuleFor(x => x.ModelYear)
            .NotEmpty();
        
        RuleFor(x => x.Nickname)
            .NotEmpty();
        
        RuleFor(x => x.Color)
            .NotEmpty();
        
        RuleFor(x => x.ManufacturerId)
            .NotEmpty();
        
        RuleFor(x => x.ModelId)
            .NotEmpty();
    }
}