using BuildingBlocks.Exceptions;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Sober.Application.Interfaces;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.TagAggregates;
using System.Text.Json;

namespace Sober.Application.Pages.Tags.Queries;

public record GetTagByIdQuery(Guid tagId) : IRequest<TagResponse>
{
}

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagResponse>
{
    private readonly ITagRepository _tagRepository;
    private readonly IDistributedCache _cache;
    private readonly IMapper _mapper;

    public GetTagByIdQueryHandler(ITagRepository tagRepository, IDistributedCache cache)
    {
        _tagRepository = tagRepository;
        _cache = cache;
    }

    public async Task<TagResponse> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {        
        string cacheKey = $"tag:{request.tagId}";
        var cached = await _cache.GetStringAsync(cacheKey, cancellationToken);

        if (!string.IsNullOrEmpty(cached))
        {
            try
            {
                var cachedTag = JsonSerializer.Deserialize<TagResponse>(cached);
                if (cachedTag is not null)
                {
                    return cachedTag;
                }
                
            }
            catch (JsonException)
            {
                await _cache.RemoveAsync(cacheKey, cancellationToken);
            }
        }

        var tag = await _tagRepository.GetTagByIdAsync(request.tagId);
        if(tag is null)
        {
            throw new NotFoundException($"Tag with ID {request.tagId} not found.");
        }

        var mappedTag = tag.Adapt<TagResponse>();
        if (mappedTag is not null)
        {
            var cacheOptions = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            var serialized = JsonSerializer.Serialize(tag);
            await _cache.SetStringAsync(cacheKey, serialized, cacheOptions, cancellationToken);
        }

        return mappedTag;
    }
}

