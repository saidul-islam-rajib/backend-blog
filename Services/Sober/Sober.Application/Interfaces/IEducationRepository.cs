using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Interfaces;

public interface IEducationRepository
{
    void AddEducation(Education education);
    Task<bool> UpdateEducationAsync(Education education);
    bool DeleteEducation(Guid id);
    Task<IEnumerable<Education>> GetAllEducationsAsync();
    Task<Education> GetEducationByIdAsync(Guid id);
}
