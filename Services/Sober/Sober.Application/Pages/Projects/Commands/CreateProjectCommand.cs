using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.ProjectAggregates;

namespace Sober.Application.Pages.Projects.Commands;

public record CreateProjectCommand(
    Guid UserId,
    Guid PostId,
    string ProjectTitle,
    string ProjectSummary,
    string ProjectSrcLink,
    string ProjectImage,
    List<ProjectTopicCommand> ProjectTopics,
    DateTime DisplayDate,
    DateTime StartDate,
    DateTime EndDate) : IRequest<ErrorOr<Project>>;

public record ProjectTopicCommand(
    Guid TopicId,
    List<ProjectTopicTagCommand> ProjectTags);
public record ProjectTopicTagCommand(Guid TagId);