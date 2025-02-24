using Sober.Domain.Aggregates.InterestAggregates.Entities;
using Sober.Domain.Aggregates.InterestAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.InterestAggregates;

public sealed class Interest : AggregateRoot<InterestId>
{
    private readonly List<InterestKey> _keys = new();
    public string Title { get; set; } = null!;
    public UserId UserId { get; private set; } = null!;
    public ICollection<InterestKey> Keys => _keys.AsReadOnly();

    private Interest(
        InterestId interestId,
        string title,
        UserId userId,
        List<InterestKey> keys)
        : base(interestId)
    {
        Title = title;
        _keys = keys;
        UserId = userId;
    }

    public static Interest Create(string title, UserId userId, List<InterestKey> keys)
    {
        Interest response = new Interest(InterestId.CreateUnique(), title, userId, keys);
        return response;
    }

    public Interest()
    {
    }
}
