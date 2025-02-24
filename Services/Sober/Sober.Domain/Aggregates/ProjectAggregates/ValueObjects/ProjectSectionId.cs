using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;

public sealed class ProjectSectionId : ValueObject
{
    public Guid Value { get; private set; }
    public ProjectSectionId(Guid value)
    {
        Value = value;
    }

    public static ProjectSectionId CreateUnique()
    {
        return new ProjectSectionId(Guid.NewGuid());
    }

    public static ProjectSectionId Create(Guid value)
    {
        return new ProjectSectionId(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
