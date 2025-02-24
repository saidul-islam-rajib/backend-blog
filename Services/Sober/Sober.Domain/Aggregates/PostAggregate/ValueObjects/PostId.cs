using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.ValueObjects
{
    public sealed class PostId : ValueObject
    {
        public Guid Value { get; private set; }
        public PostId(Guid value)
        {
            Value = value;
        }

        public static PostId CreateUnique()
        {
            return new PostId(Guid.NewGuid());
        }

        public static PostId Create(Guid value)
        {
            return new PostId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
