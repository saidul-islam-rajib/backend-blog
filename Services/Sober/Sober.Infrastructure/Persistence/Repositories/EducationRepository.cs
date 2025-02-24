using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class EducationRepository : IEducationRepository
    {
        private readonly BlogDbContext _dbContext;

        public EducationRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEducation(Education education)
        {
            _dbContext.Add(education);
            _dbContext.SaveChanges();
        }

        public bool DeleteEducation(Guid id)
        {
            var education = _dbContext.Educations.Find(new EducationId(id));
            if(education is null)
            {
                return false;
            }
            _dbContext.Educations.Remove(education);
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<Education>> GetAllEducations()
        {
            IEnumerable<Education> response = await _dbContext.Educations.AsNoTracking().OrderByDescending(e => e.EndDate).ToListAsync();
            return response;
        }

        public async Task<Education?> GetEducationById(Guid id)
        {
            var response = await _dbContext.Educations
                .Include(education => education.EducationSection)
                .FirstOrDefaultAsync(edu => edu.Id.Equals(new EducationId(id)));

            return response;
        }
    }
}
