namespace Sober.Contracts.Request;

public record AdditionalSkillRequest(string Title, List<AdditionalSkillKeyRequest> Keys);

public record AdditionalSkillKeyRequest(string Key);