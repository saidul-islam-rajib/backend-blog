using BuildingBlocks.Pagination;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Posts.Queries.Query;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.QueryHandler;

public class GetPaginatedPostsQueryHandler : IRequestHandler<GetPaginatedPostsQuery, PaginationResult<Post>>
{
    private readonly IPostRepository _repository;

    public GetPaginatedPostsQueryHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginationResult<Post>> Handle(GetPaginatedPostsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetPaginatedPostsAsync(request.PageNumber, request.PageSize, cancellationToken);
    }
}


