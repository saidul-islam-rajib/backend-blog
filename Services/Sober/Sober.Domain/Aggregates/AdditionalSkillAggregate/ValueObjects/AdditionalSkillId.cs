using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.AdditionalSkillAggregate.ValueObjects;

public sealed class AdditionalSkillId : ValueObject
{
    public Guid Value { get; private set; }
    public AdditionalSkillId(Guid value)
    {
        Value = value;
    }

    public static AdditionalSkillId CreateUnique()
    {
        return new AdditionalSkillId(Guid.NewGuid());
    }

    public static AdditionalSkillId Create(Guid value)
    {
        return new AdditionalSkillId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
