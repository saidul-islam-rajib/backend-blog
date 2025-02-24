namespace Sober.Contracts.Response;

public record InterestResponse
(Guid InterestId, string UserId, string Title, List<InterestKeyResponse> Keys, string? Image);

public record InterestKeyResponse(string InterestKeyId, string Key);
