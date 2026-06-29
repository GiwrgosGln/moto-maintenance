using FluentValidation;

namespace MotoMaintenance.Api.Features.Manufacturers.ListManufacturers;

public sealed class ListManufacturersValidator : AbstractValidator<ListManufacturersQuery>
{
    public ListManufacturersValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
        RuleFor(x => x.SortBy)
            .Must(s => s is null
                       || s.Equals("name", StringComparison.OrdinalIgnoreCase)
                       || s.Equals("createdat", StringComparison.OrdinalIgnoreCase))
            .WithMessage("SortBy must be 'name' or 'createdat'.");
    }
}