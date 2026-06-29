using FluentValidation;

namespace MotoMaintenance.Api.Features.Models.ListModels;

public sealed class ListModelsValidator : AbstractValidator<ListModelsQuery>
{
    public ListModelsValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page must be greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");

        RuleFor(x => x.SortBy)
            .Must(s => s is null
                       || s.Equals("name", StringComparison.OrdinalIgnoreCase)
                       || s.Equals("createdat", StringComparison.OrdinalIgnoreCase)
                       || s.Equals("manufacturerid", StringComparison.OrdinalIgnoreCase))
            .WithMessage("SortBy must be 'name', 'createdat', or 'manufacturerid'.");

        RuleFor(x => x.ManufacturerId).NotEmpty().When(x => x.ManufacturerId.HasValue);
    }
}