using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.SkillAggregate;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly BlogDbContext _dbContext;

        public SkillRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateSkill(Topic skill)
        {
            _dbContext.Add(skill);
            _dbContext.SaveChanges();
        }

        public bool DeleteSkill(Guid skillId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Topic>> GetAllSkillAsync()
        {
            var response = await _dbContext.Topics.AsNoTracking().ToListAsync();
            return response;
        }

        public async Task<Topic> GetSkillByIdAsync(Guid skillId)
        {
            var response = await _dbContext.Topics.FirstOrDefaultAsync(skill => skill.Id.Equals(new TopicId(skillId)));
            return response;
        }
    }
}
