using Mapster;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Api.Common.Mappings;

public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserResponse>()
            .Map(dest => dest.UserId, src => src.Id.Value)
            .Map(dest => dest.Fullname, src => src.Name);
    }
}
