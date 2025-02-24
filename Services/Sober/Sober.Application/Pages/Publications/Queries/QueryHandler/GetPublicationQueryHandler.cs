using MapsterMapper;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Publications.Queries.Query;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.Publications.Queries.QueryHandler;

public class GetPublicationQueryHandler
    : IRequestHandler<GetPublicationQuery, IEnumerable<PublicationResponse>>
{
    private readonly IPublicationRepository _repository;
    private readonly IMapper _mapper;

    public GetPublicationQueryHandler(IPublicationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PublicationResponse>> Handle(GetPublicationQuery request, CancellationToken cancellationToken)
    {
        //const string cacheKey = "GetAllPublications";
        //var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);

        //if (!string.IsNullOrEmpty(cachedData))
        //{
        //    // Deserialize cached data and return
        //    var cachedPublications = JsonSerializer.Deserialize<IEnumerable<PublicationResponse>>(cachedData);
        //    return cachedPublications ?? Enumerable.Empty<PublicationResponse>();
        //}

        var publicationsFromDb = await _repository.GetAllPublicationAsync();
        var mappedPublications = _mapper.Map<IEnumerable<PublicationResponse>>(publicationsFromDb);

        // Serialize and cache the mapped result
        //var cacheOptions = new DistributedCacheEntryOptions
        //{
        //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
        //    SlidingExpiration = TimeSpan.FromMinutes(10)
        //};
        //var serializedData = JsonSerializer.Serialize(mappedPublications);
        //await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

        return mappedPublications;
    }
}
