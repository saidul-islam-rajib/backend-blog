using FluentValidation;

namespace Sober.Application.Pages.Topics.Commands
{
    public class CreateTopicCommandValidator : AbstractValidator<CreateTopicCommand>
    {
        public CreateTopicCommandValidator()
        {
            RuleFor(x => x.skillName).NotEmpty();
        }
    }
}
