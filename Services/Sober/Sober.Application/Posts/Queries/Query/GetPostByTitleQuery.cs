using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.Query
{
    public record GetPostByTitleQuery(string title) : IRequest<IEnumerable<Post>>
    {

    }
}
