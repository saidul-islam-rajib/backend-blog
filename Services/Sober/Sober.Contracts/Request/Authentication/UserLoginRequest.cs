namespace Sober.Contracts.Request.Authentication
{
    public record UserLoginRequest(
        string Email,
        string Password);
}
