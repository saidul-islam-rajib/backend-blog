using ErrorOr;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;
using System.Text.Json;

namespace Sober.Application.Pages.Tags.Commands;

public class CreateTagCommandHandler
    : IRequestHandler<CreateTagCommand, ErrorOr<Tag>>
{
    private readonly ITagRepository _repository;
    private readonly IDistributedCache _cache;

    public CreateTagCommandHandler(ITagRepository repository, IDistributedCache cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<ErrorOr<Tag>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Tag tag = Tag.Create(request.TagName, TopicId.Create(request.TopicId));
        _repository.AddTag(tag);

        var tagCacheKey = $"tag:{tag.Id}";
        var tagJson = JsonSerializer.Serialize(tag);
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(10)
        };
        await _cache.SetStringAsync(tagCacheKey, tagJson, options, cancellationToken);

        // Invalidate "all tags" cache to ensure freshness
        await _cache.RemoveAsync("tags:all", cancellationToken);

        return tag;
    }
}
