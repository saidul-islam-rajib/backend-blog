using MediatR;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.UserInterests.Queries;

public record GetInterestQuery() : IRequest<IEnumerable<InterestResponse>>
{
}
