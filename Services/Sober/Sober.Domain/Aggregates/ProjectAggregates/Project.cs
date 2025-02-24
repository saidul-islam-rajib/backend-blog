using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.ProjectAggregates.Entities;
using Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.ProjectAggregates;

public sealed class Project : AggregateRoot<ProjectId>
{
    private readonly List<ProjectSection> _projectSection = new();
    public string ProjectTitle { get; private set; } = null!;
    public string ProjectSummary { get; private set; } = null!;
    public string ProjectSrcLink { get; private set; } = null!;
    public string ProjectImage { get; private set; } = null!;
    public DateTime? DisplayDate { get; private set; }
    public DateTime? StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public UserId UserId { get; private set; }
    public PostId PostId { get; private set; }
    public ICollection<ProjectSection> ProjectSection => _projectSection.AsReadOnly();

    private Project(
        ProjectId projectId, List<ProjectSection> projectSection, string projectTitle, string projectSummary, string projectSrcLink, string projectImage, UserId userId, PostId postId, DateTime? displayDate, DateTime? startDate, DateTime? endDate) : base(projectId)
    {
        _projectSection = projectSection;
        ProjectTitle = projectTitle;
        ProjectSummary = projectSummary;
        ProjectSrcLink = projectSrcLink;
        ProjectImage = projectImage;
        DisplayDate = displayDate;
        StartDate = startDate;
        EndDate = endDate;
        UserId = userId;
        PostId = postId;
    }

    public static Project Create(
            List<ProjectSection> projectSection,            
            string projectTitle,
            string projectSummary,
            string projectSrcLink,
            string projectImage,
            UserId userId,
            PostId postId,
            DateTime? displayDate,
            DateTime? startDate,
            DateTime? endDate
        )
    {
        Project project = new Project(
            ProjectId.CreateUnique(), projectSection, projectTitle, projectSummary, projectSrcLink, projectImage, userId,
            postId, displayDate, startDate, endDate);

        return project;

    }

    public Project()
    {
        
    }
}
