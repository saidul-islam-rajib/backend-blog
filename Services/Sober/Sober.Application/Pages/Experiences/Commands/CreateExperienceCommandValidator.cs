using FluentValidation;

namespace Sober.Application.Pages.Experiences.Commands
{
    public class CreateExperienceCommandValidator : AbstractValidator<CreateExperienceCommand>
    {
        public CreateExperienceCommandValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty();
            RuleFor(x => x.Designation).NotEmpty();
            RuleFor(x => x.IsCurrentEmployee).NotNull();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.IsFullTimeEmployee).NotNull();
            RuleFor(x => x.ExperienceSection).NotEmpty();
        }
    }
}
