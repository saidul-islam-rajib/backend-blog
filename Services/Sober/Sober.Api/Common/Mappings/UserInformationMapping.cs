using Mapster;
using Sober.Application.Pages.Users.Commands;
using Sober.Contracts.Request.UserInformation;
using Sober.Contracts.Response.UserInformation;
using Sober.Domain.Aggregates.UserInformationAggregate;

namespace Sober.Api.Common.Mappings;

public class UserInformationMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(UserInformationRequest Request, Guid UserId), CreateUserInformationCommand>()
                .Map(dest => dest.UserId, src => src.UserId)
                .Map(dest => dest, src => src.Request);

        config.NewConfig<UserInformation, UserInformationResponse>()
            .Map(dest => dest.UserInformationId, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId.Value)
            .Map(dest => dest.UserName, src => src.User.Name)
            .Map(dest => dest.EmailAddress, src => src.User.Email)
            .Map(dest => dest.UserBio, src => src.Bio);
    }
}
