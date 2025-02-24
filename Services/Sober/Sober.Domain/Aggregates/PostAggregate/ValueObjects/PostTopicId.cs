using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.ValueObjects
{
    public sealed class PostTopicId : ValueObject
    {
        public Guid Value { get; private set; }
        public PostTopicId(Guid value)
        {
            Value = value;
        }

        public static PostTopicId CreateUqique()
        {
            return new (Guid.NewGuid());
        }
        public static PostTopicId Create(Guid value)
        {
            return new PostTopicId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
