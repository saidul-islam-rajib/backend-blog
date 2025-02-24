using Sober.Domain.Aggregates.AdditionalSkillAggregate;

namespace Sober.Application.Interfaces;

public interface IAdditionalSkillRepository
{
    void AddAdditionalSkillAsync(AdditionalSkill additionalSkill);
    Task<bool> UpdateAdditionalSkillAsync(AdditionalSkill additionalSkill);
    bool DeleteAdditionalSkillAsync(Guid additionalSkillId);
    Task<IEnumerable<AdditionalSkill>> GetAllAdditionalSkillAsync();
    Task<AdditionalSkill> GetAdditionalSkillByIdAsync(Guid additionalSkillId);
}
