using Mapster;
using Sober.Application.Pages.Feedbacks.Commands;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Api.Common.Mappings;

public class FeedbackMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FeedbackRequest, CreateFeedbackCommand>()
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Comment, src => src.Comment)
            .Map(dest => dest.GuestIpAddress, src => src.GuestIpAddress);

        config.NewConfig<Feedback, FeedbackResponse>()
            .Map(dest => dest.FeedbackId, src => src.Id.Value)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Comment, src => src.Comment)
            .Map(dest => dest.GuestIpAddress, src => src.GuestIpAddress);

        config.NewConfig<(UpdateFeedbackRequest Request, Guid UserId, Guid FeedbackId), UpdateFeedbackCommand>()
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.FeedbackId, src => src.FeedbackId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Feedback, UpdateFeedbackResponse>()
            .Map(dest => dest.FeedbackId, src => src.Id.Value)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Comment, src => src.Comment)
            .Map(dest => dest.GuestIpAddress, src => src.GuestIpAddress);
    }
}
