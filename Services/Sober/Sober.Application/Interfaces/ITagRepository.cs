using Sober.Contracts.Response;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Interfaces;

public interface ITagRepository
{
    void AddTag(Tag tag);
    Task<bool> UpdateTagAsync(Tag tag);
    bool DeleteTag(Guid tagId);
    Task<IEnumerable<Tag>> GetAllTagAsync();
    Task<IEnumerable<TagWithTopicResponse>> GetTagWithTopicAsync(CancellationToken cancellationToken);
    string GetTagNameById(Guid tagId);
    Task<Tag?> GetTagByIdAsync(Guid tagId);
}
