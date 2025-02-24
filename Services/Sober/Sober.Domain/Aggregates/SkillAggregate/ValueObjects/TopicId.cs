using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.SkillAggregate.ValueObjects
{
    public sealed class TopicId : ValueObject
    {
        public Guid Value { get; private set; }
        public TopicId(Guid value)
        {
            Value = value;
        }

        public static TopicId CreateUnique()
        {
            return new TopicId(Guid.NewGuid());
        }

        public static TopicId Create(Guid value)
        {
            return new TopicId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
