using FluentValidation;

namespace Sober.Application.Pages.Tags.Commands;

public class CreateTagValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagValidator()
    {
        RuleFor(x => x.TagName).NotEmpty();
    }
}
