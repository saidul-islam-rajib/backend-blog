using MediatR;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.Query
{
    public record GetCommentByIdQuery(Guid commentId) : IRequest<Comment>
    {
    }
}
