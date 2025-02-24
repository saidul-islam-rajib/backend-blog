using Sober.Domain.Aggregates.InterestAggregates;

namespace Sober.Application.Interfaces;

public interface IInterestRepository
{
    void AddInterest(Interest interest);
    Task<bool> UpdateInterestAsync(Interest interest);
    bool DeleteInterest(Guid interestId);
    Task<IEnumerable<Interest>> GetAllInterestAsync();
    Task<Interest?> GetInterestByIdAsync(Guid interestId);
}
