namespace Sober.Contracts.Response;


public record AdditionalSkillResponse
(Guid AdditionalSkillId, string UserId, string Title, List<AdditionalSkillKeyResponse> Keys);

public record AdditionalSkillKeyResponse(string AdditionalSkillKeyId, string Key);
