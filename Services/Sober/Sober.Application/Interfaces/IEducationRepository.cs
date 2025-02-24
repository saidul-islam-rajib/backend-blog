using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Interfaces
{
    public interface IEducationRepository
    {
        void AddEducation(Education education);
        bool DeleteEducation(Guid id);
        Task<IEnumerable<Education>> GetAllEducations();
        Task<Education> GetEducationById(Guid id);
    }
}
