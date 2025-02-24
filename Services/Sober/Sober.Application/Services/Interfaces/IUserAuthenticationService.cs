using ErrorOr;
using Sober.Application.Services.Authentication.Common;

namespace Sober.Application.Services.Interfaces;

public interface IUserAuthenticationService
{
    ErrorOr<AuthenticationResult> Login(string email, string password);
    ErrorOr<AuthenticationResult> Register(string name, string email, string password);
}
