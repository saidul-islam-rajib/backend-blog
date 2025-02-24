using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PostAggregate.ValueObjects;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.ProjectAggregates.Entities;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.Projects.Commands;

public class CreateProjectCommandHandler
    : IRequestHandler<CreateProjectCommand, ErrorOr<Project>>
{
    private readonly IProjectRepository _repository;

    public CreateProjectCommandHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Project>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. Create Project
        Project project = Project.Create(
            request.ProjectTopics.ConvertAll(section => ProjectSection.Create(
                TopicId.Create(section.TopicId),
                section.ProjectTags.ConvertAll(tag => ProjectTag.Create(
                    TagId.Create(tag.TagId)
                    )))),
            request.ProjectTitle,
            request.ProjectSummary,
            request.ProjectSrcLink,
            request.ProjectImage,
            UserId.Create(request.UserId),
            PostId.Create(request.PostId),
            request.DisplayDate,
            request.StartDate,
            request.EndDate);

        // 2. Persist into DB
        _repository.CreateProject(project);

        // 3. Return project
        return project;
    }
}
