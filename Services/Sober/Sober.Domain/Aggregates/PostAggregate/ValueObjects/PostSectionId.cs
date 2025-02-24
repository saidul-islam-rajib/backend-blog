using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PostAggregate.ValueObjects
{
    public sealed class PostSectionId : ValueObject
    {
        public Guid Value { get; private set; }
        public PostSectionId(Guid value)
        {
            Value = value;
        }

        public static PostSectionId CreateUqique()
        {
            return new PostSectionId(Guid.NewGuid());
        }
        public static PostSectionId Create(Guid value)
        {
            return new PostSectionId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
