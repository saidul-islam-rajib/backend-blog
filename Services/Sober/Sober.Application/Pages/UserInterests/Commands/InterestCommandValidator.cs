using FluentValidation;

namespace Sober.Application.Pages.UserInterests.Commands;

public class InterestCommandValidator : AbstractValidator<CreateInterestCommand>
{
    public InterestCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}
