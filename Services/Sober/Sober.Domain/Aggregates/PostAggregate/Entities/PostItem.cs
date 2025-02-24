using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.Entities
{
    public sealed class PostItem : Entity<PostItemId>
    {
        public string PostItemTitle { get; private set; } = null!;
        public string? PostItemImage { get; private set;}
        public string PostItemDescription { get; private set; } = null!;

        private PostItem(
            PostItemId postItemId,
            string postItemTitle,            
            string postItemDescription,
            string? postItemImage) : base(postItemId)
        {
            PostItemTitle = postItemTitle;
            PostItemImage = postItemImage;
            PostItemDescription = postItemDescription;
        }

        public static PostItem Create(
            string postItemTitle,
            string postItemDescription,
            string? postItemImage)
        {
            PostItem items = new PostItem(PostItemId.CreateUqique(), postItemTitle, postItemDescription, postItemImage);
            return items;
        }


        private PostItem()
        {
        }
    }
}
