using FluentValidation;

namespace Sober.Application.Posts.Commands
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.PostTitle).NotEmpty();
            RuleFor(x => x.PostAbstract).NotEmpty();
            RuleFor(x => x.Sections).NotEmpty();
        }
    }
}
