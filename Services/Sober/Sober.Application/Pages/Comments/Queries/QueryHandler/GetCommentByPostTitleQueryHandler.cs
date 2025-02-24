using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Comments.Queries.Query;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Application.Pages.Comments.Queries.QueryHandler
{
    public class GetCommentByPostTitleQueryHandler : IRequestHandler<GetCommentByPostTitleQuery, IEnumerable<Comment>>
    {
        private readonly ICommentRepository _commentRepository;

        public GetCommentByPostTitleQueryHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<IEnumerable<Comment>> Handle(GetCommentByPostTitleQuery request, CancellationToken cancellationToken)
        {
            var response = await _commentRepository.GetCommentByPostTitle(request.postTitle);
            return response;
        }
    }
}
