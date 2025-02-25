using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.Entities
{
    public sealed class PostSection : Entity<PostSectionId>
    {
        private readonly List<PostItem> _items = new();
        public string SectionTitle { get; private set; } = null!;
        public string? SectionImage { get; set; }
        public string SectionDescription { get; private set; } = null!;
        public ICollection<PostItem> Items => _items;

        private PostSection(
            PostSectionId sectionId,
            string sectionTitle,
            string sectionDescription,
            List<PostItem> items,
            string? sectionImage) : base(sectionId)
        {
            SectionTitle = sectionTitle;
            SectionDescription = sectionDescription;
            SectionImage = sectionImage;
            _items = items;
        }

        public static PostSection Create(
            string sectionTitle,
            string sectionDescription,
            List<PostItem> items,
            string? sectionImage)
        {
            PostSection section = new PostSection(PostSectionId.CreateUqique(), sectionTitle, sectionDescription, items, sectionImage);
            return section;
        }

        public PostSection()
        {
            
        }
    }
}
