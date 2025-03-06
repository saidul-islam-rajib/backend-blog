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
        config.NewConfig<(InterestRequest Request, Guid UserId, string LogoPath), CreateInterestCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Image, src => src.LogoPath)
            .Map(dest => dest.Keys, src => src.Request.Keys)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<InterestKeyRequest, InterestKeyCommand>()
            .Map(dest => dest.Key, src => src.Key);

        config.NewConfig<(UpdateInterestRequest Request, Guid InterestId, Guid UserId, string LogoPath), UpdateInterestCommand>()
            .Map(dest => dest.InterestId, src => src.InterestId)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Title, src => src.Request.Title)
            .Map(dest => dest.Image, src => src.LogoPath)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<UpdateInterestKeyRequest, UpdateInterestKeyCommand>()
            .Map(dest => dest.Key, src => src.Key);



        config.NewConfig<Interest, InterestResponse>()
            .Map(dest => dest.InterestId, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.Image, src => src.Image);

        config.NewConfig<InterestKey, InterestKeyResponse>()
            .Map(dest => dest.InterestKeyId, src => src.Id.Value)
            .Map(dest => dest.Key, src => src.Key);
    }
}
