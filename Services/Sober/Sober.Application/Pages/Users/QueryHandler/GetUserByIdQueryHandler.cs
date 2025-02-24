using MediatR;
using Sober.Application.Common.Interfaces.Persistence;
using Sober.Application.Pages.Users.Queries;
using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Application.Pages.Users.QueryHandler;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
{
    private readonly IUserRepository _repository;

    public GetUserByIdQueryHandler(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetUserByIdAsync(request.userId);
        return response;
    }
}
