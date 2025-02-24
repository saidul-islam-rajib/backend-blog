using Mapster;
using Sober.Application.Pages.Topics.Commands;
using Sober.Contracts.Request.Skills;
using Sober.Contracts.Response.Skills;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Api.Common.Mappings
{
    public class TopicMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SkillRequest, CreateTopicCommand>();
            config.NewConfig<Topic, SkillResponse>()
                .Map(dest => dest.SkillId, src => src.Id.Value)
                .Map(dest => dest.SkillName, src => src.TopicName);
        }
    }
}
