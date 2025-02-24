using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
