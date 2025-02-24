namespace Sober.Contracts.Request.Authentication;

public record UserRegisterRequest(
    string Name,
    string Email,
    string Password);
