using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Comments.Queries.Query;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.QueryHandler
{
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _commentRepository.GetCommentByIdAsync(request.commentId);
            return response;
        }
    }
}
