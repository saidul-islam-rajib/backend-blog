using Mapster;
using Sober.Application.Pages.Publications.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.PublicationAggregate.Entities;

namespace Sober.Api.Common.Mappings;

public class PublicationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(PublicationRequest Request, Guid UserId), CreatePublicationCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Publication, PublicationResponse>()
            .Map(dest => dest.PublicationId, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.Title, src => src.Title)
            .Map(dest => dest.JournalName, src => src.JournalName)
            .Map(dest => dest.Summary, src => src.Summary);

        config.NewConfig<PublicationKey, PublicationKeyResponse>()
            .Map(dest => dest.PublicationKeyId, src => src.Id.Value)
            .Map(dest => dest.Key, src => src.Key);
    }
}
