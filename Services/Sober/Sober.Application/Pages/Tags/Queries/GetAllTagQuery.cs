using MediatR;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Queries;

public record GetAllTagQuery
    : IRequest<IEnumerable<Tag>>
{
}
