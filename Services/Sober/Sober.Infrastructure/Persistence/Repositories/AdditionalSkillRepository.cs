using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.AdditionalSkillAggregate;
using Sober.Domain.Aggregates.AdditionalSkillAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories;

public class AdditionalSkillRepository : IAdditionalSkillRepository
{
    private readonly BlogDbContext _dbContext;

    public AdditionalSkillRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddAdditionalSkillAsync(AdditionalSkill additionalSkill)
    {
        _dbContext.Add(additionalSkill);
        _dbContext.SaveChangesAsync();
    }

    public bool DeleteAdditionalSkillAsync(Guid additionalSkillId)
    {
        var additionalSkill = _dbContext.AdditionalSkills.Find(new AdditionalSkillId(additionalSkillId));
        if (additionalSkill is null)
        {
            return false;
        }

        _dbContext.AdditionalSkills.Remove(additionalSkill);
        _dbContext.SaveChanges();
        return true;
    }

    public async Task<AdditionalSkill> GetAdditionalSkillByIdAsync(Guid additionalSkillId)
    {
        var response = await _dbContext.AdditionalSkills
                        .Include(skill => skill.Keys)
                        .FirstOrDefaultAsync(p => p.Id.Equals(new AdditionalSkillId(additionalSkillId)));

        return response;
    }

    public async Task<IEnumerable<AdditionalSkill>> GetAllAdditionalSkillAsync()
    {
        var response = await _dbContext.AdditionalSkills.AsNoTracking().ToListAsync();
        return response;
    }

    public async Task<bool> UpdateAdditionalSkillAsync(AdditionalSkill additionalSkill)
    {
        var existingAdditionalSkill = await _dbContext.AdditionalSkills
                        .Include(p => p.Keys)
                        .FirstOrDefaultAsync(p => p.Id == additionalSkill.Id);

        if (existingAdditionalSkill is null)
        {
            return false;
        }

        // Update properties of the existing publicatoin
        existingAdditionalSkill.Title = additionalSkill.Title;

        existingAdditionalSkill.Keys.Clear();
        foreach (var key in existingAdditionalSkill.Keys)
        {
            existingAdditionalSkill.Keys.Add(key);
        }

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
