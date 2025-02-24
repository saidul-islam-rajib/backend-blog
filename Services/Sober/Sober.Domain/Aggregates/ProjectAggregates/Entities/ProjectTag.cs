using Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ProjectAggregates.Entities;

public class ProjectTag : Entity<ProjectTagId>
{
    public TagId TagId { get; private set; }
    public Tag Tag { get; private set; } = null!;

    private ProjectTag(ProjectTagId id, TagId tagId) : base(id)
    {
        TagId = tagId;
    }

    public static ProjectTag Create(TagId tagId)
    {
        ProjectTag projectTag = new ProjectTag(ProjectTagId.CreateUnique(), tagId);
        return projectTag;
    }
}
