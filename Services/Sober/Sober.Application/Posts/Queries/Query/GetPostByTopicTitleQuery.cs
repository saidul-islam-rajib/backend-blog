using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.Query
{
    public record GetPostByTopicTitleQuery(string topicTitle) : IRequest<IEnumerable<Post>>
    {
    }
}
