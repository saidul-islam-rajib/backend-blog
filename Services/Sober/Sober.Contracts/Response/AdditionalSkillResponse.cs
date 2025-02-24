namespace Sober.Contracts.Response;


public record AdditionalSkillResponse
(Guid AdditionalSkillId, string UserId, string Title, string? Image, List<AdditionalSkillKeyResponse> Keys);

public record AdditionalSkillKeyResponse(string AdditionalSkillKeyId, string Key);
