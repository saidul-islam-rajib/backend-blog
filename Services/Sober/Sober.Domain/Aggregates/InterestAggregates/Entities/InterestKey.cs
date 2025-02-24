using Sober.Domain.Aggregates.InterestAggregates.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.InterestAggregates.Entities;

public sealed class InterestKey : Entity<InterestKeyId>
{
    public string Key { get; set; } = null!;
    private InterestKey(InterestKeyId interestKeyId, string key)
        : base(interestKeyId)
    {
        Key = key;
    }

    public static InterestKey Create(string key)
    {
        InterestKey interestKey = new InterestKey(InterestKeyId.CreateUnique(), key);
        return interestKey;
    }

    public InterestKey()
    {
    }
}
