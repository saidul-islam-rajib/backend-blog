using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.Entities
{
    public sealed class PostSection : Entity<PostSectionId>
    {
        private readonly List<PostItem> _items = new();
        public string SectionTitle { get; private set; } = null!;
        public string SectionDescription { get; private set; } = null!;
        public ICollection<PostItem> Items => _items;

        private PostSection(
            PostSectionId sectionId,
            string sectionTitle,
            string sectionDescription,
            List<PostItem> items) : base(sectionId)
        {
            SectionTitle = sectionTitle;
            SectionDescription = sectionDescription;
            _items = items;
        }

        public static PostSection Create(
            string sectionTitle,
            string sectionDescription,
            List<PostItem> items)
        {
            PostSection section = new PostSection(PostSectionId.CreateUqique(), sectionTitle, sectionDescription, items);
            return section;
        }

        public PostSection()
        {
            
        }
    }
}
