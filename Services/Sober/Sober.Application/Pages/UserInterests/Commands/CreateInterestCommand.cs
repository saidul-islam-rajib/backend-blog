using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.InterestAggregates;

namespace Sober.Application.Pages.UserInterests.Commands;

public record CreateInterestCommand
(
    Guid UserId,
    string Title,
    List<InterestKeyCommand> Keys
) : IRequest<ErrorOr<Interest>>;

public record InterestKeyCommand(string Key);

