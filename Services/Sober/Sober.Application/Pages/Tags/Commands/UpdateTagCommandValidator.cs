using FluentValidation;

namespace Sober.Application.Pages.Tags.Commands;

public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(x => x.TagName).NotEmpty();
    }
}
