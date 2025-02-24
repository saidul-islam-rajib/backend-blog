using Sober.Domain.Aggregates.UserAggregate;

namespace Sober.Application.Services.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token);
