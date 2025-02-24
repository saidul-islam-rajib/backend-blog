using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.InterestAggregates.ValueObjects;

public sealed class InterestId : ValueObject
{
    public Guid Value { get; private set; }
    public InterestId(Guid value)
    {
        Value = value;
    }

    public static InterestId CreateUnique()
    {
        return new InterestId(Guid.NewGuid());
    }

    public static InterestId Create(Guid value)
    {
        return new InterestId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
