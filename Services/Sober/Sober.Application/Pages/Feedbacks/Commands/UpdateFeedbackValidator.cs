using FluentValidation;

namespace Sober.Application.Pages.Feedbacks.Commands;

public class UpdateFeedbackValidator : AbstractValidator<UpdateFeedbackCommand>
{
    public UpdateFeedbackValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}
