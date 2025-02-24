using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.TagAggregates.ValueObjects;

public sealed class TagId : ValueObject
{
    public Guid Value { get; private set; }
    public TagId(Guid value)
    {
        Value = value;
    }

    public static TagId CreateUnique()
    {
        return new TagId(Guid.NewGuid());
    }

    public static TagId Create(Guid value)
    {
        return new TagId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
