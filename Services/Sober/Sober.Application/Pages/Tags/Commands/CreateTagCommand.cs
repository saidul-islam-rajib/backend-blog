using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Commands;

public record CreateTagCommand(
    Guid UserId,
    string TagName,
    Guid TopicId) : IRequest<ErrorOr<Tag>>;

