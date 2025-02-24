using ErrorOr;
using MediatR;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Application.Pages.Users.Commands;

public class CreateUserInformationCommandHandler
    : IRequestHandler<CreateUserInformationCommand, ErrorOr<UserInformation>>
{
    private readonly IUserRepository _userRepository;

    public CreateUserInformationCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserInformation>> Handle(CreateUserInformationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        User userInformation = await _userRepository.GetUserByIdAsync(request.UserId);
        if(userInformation is null)
        {
            throw new ArgumentNullException(nameof(request.UserId));
        }

        // 1. Create UserInformation
        UserInformation user = UserInformation.Create(
            request.UserBio,
            userInformation);

        // 2. Persist into DB
        _userRepository.CreateUserInformation(user);

        // 3. Return user
        return user;
    }
}
