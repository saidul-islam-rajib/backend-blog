using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.InterestAggregates.Entities;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.UserInterests.Commands;

public class InterestCommandHandler
    : IRequestHandler<CreateInterestCommand, ErrorOr<Interest>>
{
    private readonly IInterestRepository _repository;

    public InterestCommandHandler(IInterestRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Interest>> Handle(CreateInterestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Create Interest
        Interest interest = Interest.Create(
            request.Title,
            UserId.Create(request.UserId),
            request.Keys.ConvertAll(
                key => InterestKey.Create(key.Key)));

        // 2. Persist into DB
        _repository.AddInterest(interest);

        // 3. Return interest
        return interest;
    }
}
