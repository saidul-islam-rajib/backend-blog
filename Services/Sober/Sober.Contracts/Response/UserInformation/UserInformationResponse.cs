namespace Sober.Contracts.Response.UserInformation;

public record UserInformationResponse(
    Guid UserInformationId,
    Guid UserId,
    string UserName,
    string EmailAddress,
    string UserBio);