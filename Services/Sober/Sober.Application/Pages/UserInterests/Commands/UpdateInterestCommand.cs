using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.InterestAggregates;

namespace Sober.Application.Pages.UserInterests.Commands;

public record UpdateInterestCommand(
Guid UserId,
Guid InterestId,
string? Title,
string? Image,
List<UpdateInterestKeyCommand>? Keys)
: IRequest<ErrorOr<Interest>>;

public record UpdateInterestKeyCommand(string? Key);
