using MediatR;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.Query
{
    public record GetCommentByPostTitleQuery(string postTitle) : IRequest<IEnumerable<Comment>>
    {
    }
}
