using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Commands
{
    public record CreateCommentCommand(
        Guid PostId,
        string Name,
        string Comments,
        DateTime Date) : IRequest<ErrorOr<Comment>>;
}
