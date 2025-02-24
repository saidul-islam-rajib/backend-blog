using Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ProjectAggregates.Entities;

public sealed class ProjectSection : Entity<ProjectSectionId>
{
    private readonly List<ProjectTag> _tags = new();
    public TopicId TopicId { get; private set; } = null!;
    
    public Topic Topic { get; private set; } = null!;
    public ICollection<ProjectTag> ProjectTags => _tags.AsReadOnly();

    private ProjectSection(
        ProjectSectionId projectSectionId,
        TopicId topicId,
        List<ProjectTag> tags)
        : base(projectSectionId)
    {
        TopicId = topicId ?? throw new ArgumentNullException(nameof(topicId));
        _tags = tags;
    }

    public static ProjectSection Create(
        TopicId topicId,
        List<ProjectTag> tags)
    {
        ProjectSection projectSection = new ProjectSection(
            ProjectSectionId.CreateUnique(),
            topicId,
            tags);
        return projectSection;
    }
    public ProjectSection()
    {
    }
}
