using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Interfaces
{
    public interface ISkillRepository
    {
        void CreateSkill(Topic topic);
        bool DeleteSkill(Guid topicId);
        Task<IEnumerable<Topic>> GetAllSkillAsync();
        Task<Topic> GetSkillByIdAsync(Guid skillId);
    }
}
