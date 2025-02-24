using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.EducationAggregate.ValueObjects;

public sealed class EducationSectionId : ValueObject
{
    public Guid Value { get; private set; }
    public EducationSectionId(Guid value)
    {
        Value = value;
    }

    public static EducationSectionId CreateUqique()
    {
        return new EducationSectionId(Guid.NewGuid());
    }
    public static EducationSectionId Create(Guid value)
    {
        return new EducationSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
