using Microsoft.AspNetCore.Http;

namespace Sober.Contracts.Request;

public record InterestRequest
(string Title, IFormFile Image, List<InterestKeyRequest> Keys);

public record InterestKeyRequest(string Key);

