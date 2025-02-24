using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.ValueObjects
{
    public sealed class PostItemId : ValueObject
    {
        public Guid Value { get; private set; }
        public PostItemId(Guid value)
        {
            Value = value;
        }

        public static PostItemId CreateUqique()
        {
            return new PostItemId(Guid.NewGuid());
        }
        public static PostItemId Create(Guid value)
        {
            return new PostItemId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
