using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Interfaces
{
    public interface IExperienceRepository
    {
        void AddExperience(Experience experience);
        Task<bool> UpdateExperienceAsync(Experience experience);
        bool DeleteExperience(Guid experienceId);
        Task<IEnumerable<Experience>> GetAllExperienceAsync();
        Task<Experience> GetExperienceByIdAsync(Guid experienceId);
    }
}
