namespace Sober.Contracts.Request;

public record InterestRequest
(string Title, List<InterestKeyRequest> Keys);

public record InterestKeyRequest(string Key);

