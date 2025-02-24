using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.UserAggregate.ValueObjects
{
    public sealed class UserId : ValueObject
    {
        public Guid Value { get; private set; }
        public UserId(Guid value)
        {
            Value = value;
        }
        public static UserId CreateUnique()
        {
            UserId userId = new UserId(Guid.NewGuid());
            return userId;
        }

        public static UserId Create(Guid value)
        {
            return new UserId(value);
        }
        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
