using Sober.Domain.Aggregates.AdditionalSkillAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.AdditionalSkillAggregate.Entities;

public sealed class AdditionalKey : Entity<AdditionalSkillKeyId>
{
    public string Key { get; set; } = null!;
    private AdditionalKey(AdditionalSkillKeyId additionalSkillKeyId, string key)
        : base(additionalSkillKeyId)
    {
        Key = key;
    }

    public static AdditionalKey Create(string key)
    {
        AdditionalKey response = new AdditionalKey(AdditionalSkillKeyId.CreateUnique(), key);
        return response;
    }

    public AdditionalKey()
    {
    }
}