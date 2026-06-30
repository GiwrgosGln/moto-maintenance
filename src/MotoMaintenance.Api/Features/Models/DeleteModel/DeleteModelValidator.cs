using FluentValidation;

namespace MotoMaintenance.Api.Features.Models.DeleteModel;

public sealed class DeleteModelValidator : AbstractValidator<DeleteModelCommand>
{
    public DeleteModelValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}