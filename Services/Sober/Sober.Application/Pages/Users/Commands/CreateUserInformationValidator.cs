using FluentValidation;

namespace Sober.Application.Pages.Users.Commands;

public class CreateUserInformationValidator : AbstractValidator<CreateUserInformationCommand>
{
    public CreateUserInformationValidator()
    {
        RuleFor(x => x.UserBio).NotEmpty();
    }
}
