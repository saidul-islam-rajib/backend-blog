namespace Sober.Contracts.Response;

public record InterestResponse
(Guid InterestId, string UserId, string Title, List<InterestKeyResponse> Keys);

public record InterestKeyResponse(string InterestKeyId, string Key);
