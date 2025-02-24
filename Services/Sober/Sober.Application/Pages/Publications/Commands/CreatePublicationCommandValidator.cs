using FluentValidation;

namespace Sober.Application.Pages.Publications.Commands;

public class CreatePublicationCommandValidator : AbstractValidator<CreatePublicationCommand>
{
    public CreatePublicationCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Summary).NotEmpty();
    }
}
