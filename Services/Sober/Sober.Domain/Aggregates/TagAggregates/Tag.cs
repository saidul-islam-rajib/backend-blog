using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.TagAggregates;

public sealed class Tag : AggregateRoot<TagId>
{
    public string TagName { get; set; } = null!;
    public TopicId TopicId { get; private set; } = null!;
    //public Topic Topic { get; private set; } = null!;
    private Tag(TagId tagId, string tagName, TopicId topicId) : base(tagId)
    {
        TagName = tagName;
        TopicId = topicId;
    }

    public static Tag Create(string tagName, TopicId topicId)
    {
        Tag tags = new Tag(TagId.CreateUnique(), tagName, topicId);
        return tags;
    }

    public Tag()
    {
    }
}
