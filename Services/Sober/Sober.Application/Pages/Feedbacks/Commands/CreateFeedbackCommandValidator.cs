using FluentValidation;

namespace Sober.Application.Pages.Feedbacks.Commands;

public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
{
    public CreateFeedbackCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
    }
}
