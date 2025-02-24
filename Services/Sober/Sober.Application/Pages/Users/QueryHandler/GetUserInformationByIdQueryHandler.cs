using MediatR;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Application.Pages.Users.Queries;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Application.Pages.Users.QueryHandler;

public class GetUserInformationByIdQueryHandler : IRequestHandler<GetUserInformationByIdQuery, UserInformation>
{
    private readonly IUserRepository _userRepository;

    public GetUserInformationByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserInformation> Handle(GetUserInformationByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _userRepository.GetUserInformationByUserIdAsync(request.userId);
        return response;
    }
}
