using BuildingBlocks.Pagination;
using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Queries.Query;

public class GetPaginatedPostsQuery : IRequest<PaginationResult<Post>>
{
    public int PageNumber { get; }
    public int PageSize { get; }

    public GetPaginatedPostsQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

