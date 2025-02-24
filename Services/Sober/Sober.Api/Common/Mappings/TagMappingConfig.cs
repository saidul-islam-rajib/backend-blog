using Mapster;
using Sober.Application.Pages.Tags.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Api.Common.Mappings;

public class TagMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(TagRequest Request, Guid UserId), CreateTagCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<(TagRequest Request, Guid UserId, Guid TagId), UpdateTagCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.TagId, src => src.TagId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Tag, TagResponse>()
            .Map(dest => dest.TagId, src => src.Id.Value)
            .Map(dest => dest.TagName, src => src.TagName)
            .Map(dest => dest.TopicId, src => src.TopicId.Value);
    }
}
