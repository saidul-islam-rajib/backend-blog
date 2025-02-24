using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.FeedbackAggregate.ValueObjects;

public sealed class FeedbackId : ValueObject
{
    public Guid Value { get; private set; }
    public FeedbackId(Guid value)
    {
        Value = value;
    }

    public static FeedbackId CreateUnique()
    {
        return new FeedbackId(Guid.NewGuid());
    }

    public static FeedbackId Create(Guid value)
    {
        return new FeedbackId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
