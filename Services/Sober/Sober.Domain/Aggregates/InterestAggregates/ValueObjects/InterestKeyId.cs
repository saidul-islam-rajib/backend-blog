using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.InterestAggregates.ValueObjects;

public sealed class InterestKeyId : ValueObject
{
    public Guid Value { get; private set; }
    public InterestKeyId(Guid value)
    {
        Value = value;
    }

    public static InterestKeyId CreateUnique()
    {
        return new InterestKeyId(Guid.NewGuid());
    }

    public static InterestKeyId Create(Guid value)
    {
        return new InterestKeyId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
