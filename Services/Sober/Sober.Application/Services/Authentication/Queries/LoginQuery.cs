using ErrorOr;
using MediatR;
using Sober.Application.Services.Authentication.Common;

namespace Sober.Application.Services.Authentication.Queries
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
