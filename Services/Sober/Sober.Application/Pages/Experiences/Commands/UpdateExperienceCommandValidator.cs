using FluentValidation;

namespace Sober.Application.Pages.Experiences.Commands;

public class UpdateExperienceCommandValidator : AbstractValidator<UpdateExperienceCommand>
{
    public UpdateExperienceCommandValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.ExperienceId).NotEmpty();
    }
}
