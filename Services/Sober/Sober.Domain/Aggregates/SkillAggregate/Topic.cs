using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.SkillAggregate;

public sealed class Topic : AggregateRoot<TopicId>
{
    public string TopicName { get; private set; } = null!;
    public ICollection<Education> Educations { get; private set; } = new List<Education>();

    private Topic(TopicId topicId, string topicName) : base(topicId)
    {
        TopicName = topicName;
    }

    public static Topic Create(string topicName)
    {
        Topic response = new Topic(TopicId.CreateUnique(), topicName);
        return response;
    }

    private Topic()
    {            
    }
}
