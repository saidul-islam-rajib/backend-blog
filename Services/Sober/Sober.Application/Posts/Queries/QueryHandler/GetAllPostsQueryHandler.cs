using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Posts.Queries.Query;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.QueryHandler
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<Post>>
    {
        private readonly IPostRepository _repository;

        public GetAllPostsQueryHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllPostAsync();
            return response;
        }
    }
}
