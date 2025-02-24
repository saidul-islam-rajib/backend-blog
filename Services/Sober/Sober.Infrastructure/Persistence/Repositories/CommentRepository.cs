using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.CommentAggregate;
using Sober.Domain.Aggregates.CommentAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly BlogDbContext _dbContext;

        public CommentRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateComment(Comment comment)
        {
            _dbContext.Add(comment);
            _dbContext.SaveChanges();
        }

        public bool DeleteComment(Guid commentId)
        {
            var comment = _dbContext.Comments.FirstOrDefault(c => c.Id.Equals(new CommentId(commentId)));
            if (comment is null)
            {
                return false;
            }

            _dbContext.Comments.Remove(comment);
            _dbContext.SaveChanges();

            return true;
        }

        public async Task<IEnumerable<Comment>> GetAllCommentAsync()
        {
            var response = await _dbContext.Comments.AsNoTracking().OrderByDescending(comment => comment.Date).ToListAsync();
            return response;
        }

        public async Task<Comment> GetCommentByIdAsync(Guid commentId)
        {
            var response = await _dbContext.Comments.FirstOrDefaultAsync(comment => comment.Id.Equals(new CommentId(commentId)));
            return response;
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostId(Guid postId)
        {
            // TO DO: performance related issue will raise here if `comments` list are huge
            string postIdData = postId.ToString();
            var response = await _dbContext.Comments.ToListAsync();
            IEnumerable<Comment> filteredComments = response.Where(comment => comment.PostId.Value == postId).OrderByDescending(comment => comment.Date);

            return filteredComments;
        }

        public async Task<IEnumerable<Comment>> GetCommentByPostTitle(string postTitle)
        {
            var response = await _dbContext.Comments.Where(post => post.PostTitle.Contains(postTitle)).ToListAsync();
            return response;
        }
    }
}
