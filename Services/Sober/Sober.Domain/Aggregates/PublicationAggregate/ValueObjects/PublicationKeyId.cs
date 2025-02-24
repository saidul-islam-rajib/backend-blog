using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PublicationAggregate.ValueObjects
{
    public sealed class PublicationKeyId : ValueObject
    {
        public Guid Value { get; private set; }
        public PublicationKeyId(Guid value)
        {
            Value = value;
        }

        public static PublicationKeyId CreateUnique()
        {
            return new PublicationKeyId(Guid.NewGuid());
        }

        public static PublicationKeyId Create(Guid value)
        {
            return new PublicationKeyId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
