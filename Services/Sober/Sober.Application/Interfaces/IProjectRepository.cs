using BuildingBlocks.Pagination;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Interfaces;

public interface IProjectRepository
{
    void CreateProject(Project project);
    void UpdateProject(Project project);
    bool DeleteProject(Guid projectId);
    Task<IEnumerable<Project>> GetAllProjectAsync();
    Task<Project> GetProjectByIdAsync(Guid projectId);
    Task<IEnumerable<Project>> GetProjectByTitle(string projectTitle);
    Task<IEnumerable<Project>> GetProjectByTopicTitle(string topic);
    //Task<PaginationResult<Project>> GetPaginatedProjectsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);


    Task<Tag> GetTagByIdAsync(Guid tagId);
}
