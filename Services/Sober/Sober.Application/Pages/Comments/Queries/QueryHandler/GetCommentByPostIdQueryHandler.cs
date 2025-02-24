using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Comments.Queries.Query;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.QueryHandler
{
    public class GetCommentByPostIdQueryHandler : IRequestHandler<GetCommentByPostIdQuery, IEnumerable<Comment>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByPostIdQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> Handle(GetCommentByPostIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _commentRepository.GetCommentByPostId(request.postId);
            return response;
        }
    }
}
