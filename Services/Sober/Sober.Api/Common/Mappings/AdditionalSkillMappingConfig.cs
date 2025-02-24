using Mapster;
using Sober.Application.Pages.AdditionalSkills.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.AdditionalSkillAggregate;
using Sober.Domain.Aggregates.AdditionalSkillAggregate.Entities;

namespace Sober.Api.Common.Mappings;

public class AdditionalSkillMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(AdditionalSkillRequest Request, Guid UserId), CreateAdditionalSkillCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<AdditionalSkill, AdditionalSkillResponse>()
            .Map(dest => dest.AdditionalSkillId, src => src.Id.Value)
            .Map(dest => dest.Title, src => src.Title);

        config.NewConfig<AdditionalKey, AdditionalSkillKeyResponse>()
            .Map(dest => dest.AdditionalSkillKeyId, src => src.Id.Value)
            .Map(dest => dest.Key, src => src.Key);
    }
}
