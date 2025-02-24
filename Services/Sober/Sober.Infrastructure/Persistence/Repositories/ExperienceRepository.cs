using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class ExperienceRepository : IExperienceRepository
    {
        private readonly BlogDbContext _dbContext;

        public ExperienceRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddExperience(Experience experience)
        {
            _dbContext.Add(experience);
            _dbContext.SaveChanges();
        }

        public bool DeleteExperience(Guid id)
        {
            var experience = _dbContext.Experiences.Find(new ExperienceId(id));
            if (experience is null)
            {
                return false;
            }
            _dbContext.Experiences.Remove(experience);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Experience>> GetAllExperienceAsync()
        {
            var response = await _dbContext.Experiences.AsNoTracking().OrderByDescending(e => e.EndDate).ToListAsync();
            return response;
        }

        public async Task<Experience?> GetExperienceByIdAsync(Guid experienceId)
        {
            var response = await _dbContext.Experiences
                .Include(experience => experience.ExperienceSection)
                .FirstOrDefaultAsync(ex => ex.Id.Equals(new ExperienceId(experienceId)));

            return response;
        }

        public async Task<bool> UpdateExperienceAsync(Experience experience)
        {
            _dbContext.Experiences.Update(experience);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
