using FluentValidation;

namespace Sober.Application.Pages.Comments.Commands
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Comments).NotEmpty();
            RuleFor(x => x.PostId).NotEmpty();
        }
    }
}
