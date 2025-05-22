using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Caching.Distributed;
using Sober.Application.CustomeExceptions.NotFoundExceptions;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.TagAggregates;
using System.Text.Json;

namespace Sober.Application.Pages.Tags.Commands;

public class UpdateTagCommandHandler
    : IRequestHandler<UpdateTagCommand, ErrorOr<Tag>>
{
    private readonly ITagRepository _tagRepository;
    private readonly ProblemDetailsFactory _problemDetailsFactory;
    private readonly IDistributedCache _cache;

    public UpdateTagCommandHandler(ITagRepository tagRepository, ProblemDetailsFactory problemDetailsFactory, IDistributedCache cache)
    {
        _tagRepository = tagRepository;
        _problemDetailsFactory = problemDetailsFactory;
        _cache = cache;
    }

    public async Task<ErrorOr<Tag>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var tag = await _tagRepository.GetTagByIdAsync(request.TagId);
        if(tag is null)
        {
            throw new TagNotFoundException(request.TagId);
        }

        tag.TagName = request.TagName;

        var isUpdated = await _tagRepository.UpdateTagAsync(tag);
        if (!isUpdated)
        {
            throw new TagFailedException("Failed to update!");
        }


        // Update Redis cache for the tag
        var cacheKey = $"tag:{request.TagId}";
        var tagJson = JsonSerializer.Serialize(tag);
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(10)
        };

        await _cache.SetStringAsync(cacheKey, tagJson, cacheOptions, cancellationToken);

        // Invalidate the "tags:all" cache
        await _cache.RemoveAsync("tags:all", cancellationToken);

        return tag;
    }
}
