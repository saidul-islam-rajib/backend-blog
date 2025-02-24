using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;

public class ProjectTagId : ValueObject
{
    public Guid Value { get; private set; }
    public ProjectTagId(Guid value)
    {
        Value = value;
    }

    public static ProjectTagId CreateUnique()
    {
        return new ProjectTagId(Guid.NewGuid());
    }

    public static ProjectTagId Create(Guid value)
    {
        return new ProjectTagId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
