using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;

public sealed class ExperienceSectionId : ValueObject
{
    public Guid Value { get; private set; }
    public ExperienceSectionId(Guid value)
    {
        Value = value;
    }

    public static ExperienceSectionId CreateUqique()
    {
        return new ExperienceSectionId(Guid.NewGuid());
    }
    public static ExperienceSectionId Create(Guid value)
    {
        return new ExperienceSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
