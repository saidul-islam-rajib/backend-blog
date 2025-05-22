using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Sober.Application.Interfaces;
using Sober.Contracts.Response;
using System.Text.Json;

namespace Sober.Application.Pages.Tags.Queries;

public class GetAllTagQueryHandler
    : IRequestHandler<GetAllTagQuery, IEnumerable<TagResponse>>
{
    private readonly ITagRepository _repository;
    private readonly IDistributedCache _cache;
    private readonly IMapper _mapper;


    public GetAllTagQueryHandler(ITagRepository repository, IDistributedCache cache, IMapper mapper)
    {
        _repository = repository;
        _cache = cache;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TagResponse>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        const string cacheKey = "tags:all";
        var cached = await _cache.GetStringAsync(cacheKey, cancellationToken);

        if (!string.IsNullOrEmpty(cached))
        {
            var cachedTag = JsonSerializer.Deserialize<IEnumerable<TagResponse>>(cached);
            return cachedTag ?? Enumerable.Empty<TagResponse>();
        }

        var tags = await _repository.GetAllTagAsync();
        var mappedTags = _mapper.Map<IEnumerable<TagResponse>>(tags);

        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(10)
        };
        var serializedData = JsonSerializer.Serialize(mappedTags);
        await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

        return mappedTags;
    }
}
