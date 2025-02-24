using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ProjectAggregates;
using Sober.Domain.Aggregates.ProjectAggregates.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly BlogDbContext _dbContext;

    public ProjectRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateProject(Project project)
    {
        _dbContext.Add(project);
        _dbContext.SaveChangesAsync();
    }

    public bool DeleteProject(Guid projectId)
    {
        var project = _dbContext.Projects.Find(new ProjectId(projectId));
        if (project is null)
        {
            return false;
        }

        _dbContext.Projects.Remove(project);
        _dbContext.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<Project>> GetAllProjectAsync()
    {

        var projects = await _dbContext.Projects
        .AsNoTracking()
        .Include(p => p.ProjectSection)
            .ThenInclude(ps => ps.Topic)
        .Include(p => p.ProjectSection)
            .ThenInclude(ps => ps.ProjectTags)
            .ThenInclude(t => t.Tag)
        .OrderBy(p => p.DisplayDate)
        .ToListAsync();

        return projects;
    }

    public async Task<Project> GetProjectByIdAsync(Guid projectId)
    {
        var response = await _dbContext.Projects.FirstOrDefaultAsync(project => project.Id.Equals(new ProjectId(projectId)));
        return response;
    }

    public Task<IEnumerable<Project>> GetProjectByTitle(string projectTitle)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Project>> GetProjectByTopicTitle(string topic)
    {
        throw new NotImplementedException();
    }

    public async Task<Tag> GetTagByIdAsync(Guid tagId)
    {
        var tagResponse = await _dbContext.Tags.FirstOrDefaultAsync(comment => comment.Id.Equals(new TagId(tagId)));

        return tagResponse;
    }

    public void UpdateProject(Project project)
    {
        throw new NotImplementedException();
    }
}
