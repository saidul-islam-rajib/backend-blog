using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Posts.Queries.Query;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.QueryHandler
{
    public class GetPostByTitleQueryHandler : IRequestHandler<GetPostByTitleQuery, IEnumerable<Post>>
    {
        private readonly IPostRepository _repository;

        public GetPostByTitleQueryHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> Handle(GetPostByTitleQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetPostByTitle(request.title);
            return response;
        }
    }
}
