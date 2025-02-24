using FluentValidation;

namespace Sober.Application.Pages.AdditionalSkills.Commands;

public class CreateAdditionalSkillValidator : AbstractValidator<CreateAdditionalSkillCommand>
{
    public CreateAdditionalSkillValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
    }
}
