using Sober.Domain.Aggregates.AdditionalSkillAggregate.Entities;
using Sober.Domain.Aggregates.AdditionalSkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.AdditionalSkillAggregate;

public sealed class AdditionalSkill : AggregateRoot<AdditionalSkillId>
{
    private readonly List<AdditionalKey> _keys = new();
    public string Title { get; set; } = null!;
    public UserId UserId { get; private set; } = null!; 
    public ICollection<AdditionalKey> Keys => _keys.AsReadOnly();

    private AdditionalSkill(
        AdditionalSkillId additionalSkillId,
        string title,
        UserId userId,
        List<AdditionalKey> keys) : base(additionalSkillId)
    {
        UserId = userId;
        Title = title;
        _keys = keys;
    }

    public static AdditionalSkill Create(string title, UserId userId, List<AdditionalKey> keys)
    {
        AdditionalSkill response = new AdditionalSkill(AdditionalSkillId.CreateUnique(), title, userId, keys);
        return response;
    }

    public AdditionalSkill()
    {        
    }
}
