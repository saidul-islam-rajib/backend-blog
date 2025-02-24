using Mapster;
using Sober.Application.Pages.UserInterests.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.InterestAggregates.Entities;

namespace Sober.Api.Common.Mappings;

public class InterestMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(InterestRequest Request, Guid UserId), CreateInterestCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Interest, InterestResponse>()
            .Map(dest => dest.InterestId, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Title, src => src.Title);

        config.NewConfig<InterestKey, InterestKeyResponse>()
            .Map(dest => dest.InterestKeyId, src => src.Id.Value)
            .Map(dest => dest.Key, src => src.Key);
    }
}
