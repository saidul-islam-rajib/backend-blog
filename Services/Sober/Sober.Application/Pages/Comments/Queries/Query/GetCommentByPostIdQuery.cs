using MediatR;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.Query
{
    public record GetCommentByPostIdQuery(Guid postId) : IRequest<IEnumerable<Comment>>;
}
