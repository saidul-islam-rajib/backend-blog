using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.InterestAggregates;

namespace Sober.Application.Pages.UserInterests.Queries;

public class GetInterestByIdQueryHandler
    : IRequestHandler<GetInterestByIdQuery, Interest>
{
    private readonly IInterestRepository _repository;

    public GetInterestByIdQueryHandler(IInterestRepository repository)
    {
        _repository = repository;
    }

    public async Task<Interest> Handle(GetInterestByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetInterestByIdAsync(request.interestId);
        return response;
    }
}
