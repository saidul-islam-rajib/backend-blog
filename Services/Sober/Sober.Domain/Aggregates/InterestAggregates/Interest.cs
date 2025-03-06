using Sober.Domain.Aggregates.InterestAggregates.Entities;
using Sober.Domain.Aggregates.InterestAggregates.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.InterestAggregates;

public sealed class Interest : AggregateRoot<InterestId>
{
    private readonly List<InterestKey> _keys = new();
    public string Title { get; set; } = null!;
    public string? Image { get; set; }
    public UserId UserId { get; private set; } = null!;
    public ICollection<InterestKey> Keys => _keys.AsReadOnly();

    private Interest(
        InterestId interestId,
        string title,
        UserId userId,
        List<InterestKey> keys,
        string? image)
        : base(interestId)
    {
        Title = title;
        _keys = keys;
        UserId = userId;
        Image = image;
    }

    public static Interest Create(string title, UserId userId, List<InterestKey> keys, string? image)
    {
        Interest response = new Interest(InterestId.CreateUnique(), title, userId, keys, image);
        return response;
    }
    public static Interest Update(InterestId interestId, UserId userId, string title, List<InterestKey> keys, string? image)
    {
        Interest response = new Interest(interestId, title, userId, keys, image);
        return response;
    }

    public Interest()
    {
    }
}
