using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PublicationAggregate.ValueObjects;

public sealed class PublicationId : ValueObject
{
    public Guid Value { get; private set; }
    public PublicationId(Guid value)
    {
        Value = value;
    }

    public static PublicationId CreateUnique()
    {
        return new PublicationId(Guid.NewGuid());
    }

    public static PublicationId Create(Guid value)
    {
        return new PublicationId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
