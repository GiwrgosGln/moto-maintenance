using FluentValidation;

namespace MotoMaintenance.Api.Features.Models.UpdateModel;

public sealed class UpdateModelValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
    }
}