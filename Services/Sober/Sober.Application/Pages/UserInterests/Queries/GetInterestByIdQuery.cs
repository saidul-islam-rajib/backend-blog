using MediatR;
using Sober.Domain.Aggregates.InterestAggregates;

namespace Sober.Application.Pages.UserInterests.Queries;

public record GetInterestByIdQuery(Guid interestId) : IRequest<Interest>
{
}
