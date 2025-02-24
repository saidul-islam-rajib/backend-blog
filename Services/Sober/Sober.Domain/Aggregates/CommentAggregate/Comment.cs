using Sober.Domain.Aggregates.CommentAggregate.ValueObjects;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.CommentAggregate
{
    public sealed class Comment : AggregateRoot<CommentId>
    {
        public string PostTitle { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Comments { get; private set; } = null!;
        public DateTime Date { get; private set; }
        public PostId PostId { get; private set; }

        private Comment(
            CommentId commentId,
            PostId postId,
            string commentorName,
            string commentorComment,
            string postTitle) : base(commentId)
        {
            PostId = postId;
            Name = commentorName;
            Comments = commentorComment;
            PostTitle = postTitle;
            Date = DateTime.Now;
        }

        public static Comment Create(
            PostId postId,
            string commentorName,
            string commentorComment,
            string postTitle)
        {
            Comment response = new Comment(
                CommentId.CreateUnique(),
                postId,
                commentorName,
                commentorComment,
                postTitle);

            return response;
        }

        public Comment()
        {
            
        }
    }
}
