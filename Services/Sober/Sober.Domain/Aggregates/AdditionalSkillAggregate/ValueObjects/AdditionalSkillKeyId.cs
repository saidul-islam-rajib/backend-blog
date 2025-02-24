using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.AdditionalSkillAggregate.ValueObjects;

public sealed class AdditionalSkillKeyId : ValueObject
{
    public Guid Value { get; private set; }
    public AdditionalSkillKeyId(Guid value)
    {
        Value = value;
    }

    public static AdditionalSkillKeyId CreateUnique()
    {
        return new AdditionalSkillKeyId(Guid.NewGuid());
    }

    public static AdditionalSkillKeyId Create(Guid value)
    {
        return new AdditionalSkillKeyId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
