using MediatR;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.Query
{
    public record GetAllCommentsQuery : IRequest<IEnumerable<Comment>>
    {
    }
}
