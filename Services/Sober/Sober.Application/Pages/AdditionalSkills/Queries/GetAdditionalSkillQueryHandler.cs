using MapsterMapper;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.AdditionalSkills.Queries;

public class GetAdditionalSkillQueryHandler
    : IRequestHandler<GetAdditionalSkillQuery, IEnumerable<AdditionalSkillResponse>>
{
    private readonly IAdditionalSkillRepository _repository;
    private readonly IMapper _mapper;

    public GetAdditionalSkillQueryHandler(IAdditionalSkillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<AdditionalSkillResponse>> Handle(GetAdditionalSkillQuery request, CancellationToken cancellationToken)
    {
        //const string cacheKey = "GetAllAdditionalSkills";
        //var cachedData = await _cache.GetStringAsync(cacheKey, cancellationToken);

        //if (!string.IsNullOrEmpty(cachedData))
        //{
        //    // Deserialize cached data and return
        //    var cachedSkills = JsonSerializer.Deserialize<IEnumerable<AdditionalSkillResponse>>(cachedData);
        //    return cachedSkills ?? Enumerable.Empty<AdditionalSkillResponse>();
        //}

        var additionalSkillsFromDb = await _repository.GetAllAdditionalSkillAsync();
        var mappedAdditionalSkills = _mapper.Map<IEnumerable<AdditionalSkillResponse>>(additionalSkillsFromDb);

        // Serialize and cache the mapped result
        //var cacheOptions = new DistributedCacheEntryOptions
        //{
        //    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
        //    SlidingExpiration = TimeSpan.FromMinutes(10)
        //};
        //var serializedData = JsonSerializer.Serialize(mappedAdditionalSkills);
        //await _cache.SetStringAsync(cacheKey, serializedData, cacheOptions, cancellationToken);

        return mappedAdditionalSkills;
    }
}
