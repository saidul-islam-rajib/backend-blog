using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Commands;

public record UpdateTagCommand(Guid UserId, Guid TagId, string TagName)
    : IRequest<ErrorOr<Tag>>
{

}
