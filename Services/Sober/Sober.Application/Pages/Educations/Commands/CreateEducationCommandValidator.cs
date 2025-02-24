using FluentValidation;

namespace Sober.Application.Pages.Educations.Commands
{
    public class CreateEducationCommandValidator : AbstractValidator<CreateEducationCommand>
    {
        public CreateEducationCommandValidator()
        {
            RuleFor(x => x.InstituteName).NotEmpty();
            RuleFor(x => x.Department).NotEmpty();
            RuleFor(x => x.IsCurrentStudent).NotNull();
        }
    }
}
