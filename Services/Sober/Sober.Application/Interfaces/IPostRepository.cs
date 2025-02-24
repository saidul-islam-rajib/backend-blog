using BuildingBlocks.Pagination;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Interfaces
{
    public interface IPostRepository
    {
        void CreatePost(Post post);
        void UpdatePost(Post post);
        bool DeletePost(Guid postId);
        Task<IEnumerable<Post>> GetAllPostAsync();
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<IEnumerable<Post>> GetPostByTitle(string postTitle);
        Task<IEnumerable<Post>> GetPostByTopicTitle(string topic);
        Task<PaginationResult<Post>> GetPaginatedPostsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
