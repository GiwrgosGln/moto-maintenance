using FluentValidation;

namespace MotoMaintenance.Api.Features.Motorcycles.DeleteMotorcycle;

public sealed class DeleteMotorcycleValidator : AbstractValidator<DeleteMotorcycleCommand>
{
    public DeleteMotorcycleValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}