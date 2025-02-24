using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;

public sealed class ProjectId : ValueObject
{
    public Guid Value { get; private set; }
    public ProjectId(Guid value)
    {
        Value = value;
    }

    public static ProjectId CreateUnique()
    {
        return new ProjectId(Guid.NewGuid());
    }

    public static ProjectId Create(Guid value)
    {
        return new ProjectId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
