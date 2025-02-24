using Mapster;
using Microsoft.AspNetCore.Identity.Data;
using Sober.Application.Services.Authentication.Commands;
using Sober.Application.Services.Authentication.Common;
using Sober.Application.Services.Authentication.Queries;
using Sober.Contracts.Response.Authentication;

namespace Sober.Api.Common.Mappings
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Id, src => src.User.Id.Value)
                .Map(dest => dest, src => src.User);
        }
    }
}
