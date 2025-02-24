using Microsoft.AspNetCore.Http;

namespace Sober.Contracts.Request;

public record AdditionalSkillRequest(string Title, IFormFile Image, List<AdditionalSkillKeyRequest> Keys);

public record AdditionalSkillKeyRequest(string Key);