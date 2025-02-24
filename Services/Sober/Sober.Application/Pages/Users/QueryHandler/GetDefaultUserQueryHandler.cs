using MediatR;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Application.Pages.Users.Queries;
using Sober.Domain.Aggregates.UserAggregate;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Application.Pages.Users.QueryHandler
{
    public class GetDefaultUserQueryHandler : IRequestHandler<GetDefaultUserQuery, UserInformation>
    {
        private readonly IUserRepository _userRepository;

        public GetDefaultUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserInformation> Handle(GetDefaultUserQuery request, CancellationToken cancellationToken)
        {
            var response = await _userRepository.GetDefaultUser();

            return response;
        }
    }
}
