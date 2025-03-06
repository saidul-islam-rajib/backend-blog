using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.InterestAggregates.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories;

public class InterestRepository : IInterestRepository
{
    private readonly BlogDbContext _dbContext;

    public InterestRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void AddInterest(Interest interest)
    {
        _dbContext.Add(interest);
        _dbContext.SaveChangesAsync();
    }

    public bool DeleteInterest(Guid interestId)
    {
        var interest = _dbContext.Interests.Find(new InterestId(interestId));
        if (interest is null)
        {
            return false;
        }

        _dbContext.Interests.Remove(interest);
        _dbContext.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<Interest>> GetAllInterestAsync()
    {
        var response = await _dbContext.Interests.AsNoTracking().ToListAsync();
        return response;
    }

    public async Task<Interest?> GetInterestByIdAsync(Guid interestId)
    {
        var response = await _dbContext.Interests
                        .Include(interest => interest.Keys)
                        .FirstOrDefaultAsync(p => p.Id.Equals(new InterestId(interestId)));

        return response;
    }

    public async Task<bool> UpdateInterestAsync(Interest interest)
    {
        _dbContext.Interests.Update(interest);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
