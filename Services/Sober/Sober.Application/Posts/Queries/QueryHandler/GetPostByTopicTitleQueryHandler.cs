using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Posts.Queries.Query;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.QueryHandler
{
    public class GetPostByTopicTitleQueryHandler : IRequestHandler<GetPostByTopicTitleQuery, IEnumerable<Post>>
    {
        private readonly IPostRepository _repository;

        public GetPostByTopicTitleQueryHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> Handle(GetPostByTopicTitleQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetPostByTopicTitle(request.topicTitle);
            return response;
        }
    }
}
