using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.TagAggregates;
using Sober.Domain.Aggregates.TagAggregates.ValueObjects;
using System.Threading;

namespace Sober.Infrastructure.Persistence.Repositories;

public class TagRepository : ITagRepository
{
    private readonly BlogDbContext _dbContext;

    public TagRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddTag(Tag tag)
    {
        _dbContext.Tags.Add(tag);
        _dbContext.SaveChangesAsync();
    }

    public bool DeleteTag(Guid tagId)
    {
        var tag = _dbContext.Tags.Find(new TagId(tagId));
        if (tag is null)
        {
            return false;
        }

        _dbContext.Tags.Remove(tag);
        _dbContext.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<Tag>> GetAllTagAsync()
    {
        var response = await _dbContext.Tags.AsNoTracking().ToListAsync();
        return response;
    }

    public async Task<Tag?> GetTagByIdAsync(Guid tagId)
    {
        var response = await _dbContext.Tags
                        .FirstOrDefaultAsync(p => p.Id.Equals(new TagId(tagId)));

        return response;
    }

    public string GetTagNameById(Guid tagId)
    {
        return _dbContext.Tags
            .Where(t => t.Id.Value == tagId)
            .Select(t => t.TagName)
            .FirstOrDefault() ?? "Unknown";
    }

    public async Task<IEnumerable<TagWithTopicResponse>> GetTagWithTopicAsync(CancellationToken cancellationToken)
    {
        var result = await _dbContext.Tags
        .Include(tag => tag.Topic)
        .GroupBy(x => new { x.Topic.Id, x.Topic.TopicName })
        .Select(group => new TagWithTopicResponse(
            group.Key.Id.Value,
            group.Key.TopicName,

            group.Select(tag => new TagInformation(
                tag.Id.Value,
                tag.TagName
                )).ToList()
        )).ToListAsync(cancellationToken);

        return result;
    }

    public async Task<bool> UpdateTagAsync(Tag tag)
    {
        _dbContext.Tags.Update(tag);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
