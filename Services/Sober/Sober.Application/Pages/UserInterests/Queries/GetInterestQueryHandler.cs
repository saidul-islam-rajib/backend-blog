using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Sober.Application.Interfaces;
using Sober.Contracts.Response;
using System.Text.Json;

namespace Sober.Application.Pages.UserInterests.Queries;

public class GetInterestQueryHandler
    : IRequestHandler<GetInterestQuery, IEnumerable<InterestResponse>>
{
    private readonly IInterestRepository _repository;
    private readonly IMapper _mapper;
    private readonly IDistributedCache _cache;

    public GetInterestQueryHandler(IInterestRepository repository, IMapper mapper, IDistributedCache cache)
    {
        _repository = repository;
        _mapper = mapper;
        _cache = cache;
    }

    public async Task<IEnumerable<InterestResponse>> Handle(GetInterestQuery request, CancellationToken cancellationToken)
    {
        const string cacheKey = "GetInterests";
        var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);

        if (!string.IsNullOrEmpty(cachedData))
        {
            // Deserialize cached data to return
            var cachedInterests = JsonSerializer.Deserialize<IEnumerable<InterestResponse>>(cachedData);
            return cachedInterests ?? Enumerable.Empty<InterestResponse>();
        }

        var interestFromDb = await _repository.GetAllInterestAsync();
        var mappedInterest = _mapper.Map<IEnumerable<InterestResponse>>(interestFromDb);

        // Serialize and cache the mapped result
        var cacheOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
            SlidingExpiration = TimeSpan.FromMinutes(10)
        };
        var serializedData = JsonSerializer.Serialize(mappedInterest);
        await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

        return mappedInterest;
    }
}
