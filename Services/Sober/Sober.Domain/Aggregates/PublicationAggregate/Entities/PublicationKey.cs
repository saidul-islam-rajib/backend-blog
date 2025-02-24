using Sober.Domain.Aggregates.PublicationAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PublicationAggregate.Entities;

public sealed class PublicationKey : Entity<PublicationKeyId>
{
    public string Key { get; set; } = null!;
    private PublicationKey(PublicationKeyId publicationKeyId, string key)
        : base(publicationKeyId)
    {
        Key = key;
    }

    public static PublicationKey Create(string key)
    {
        PublicationKey response = new PublicationKey(PublicationKeyId.CreateUnique(), key);
        return response;
    }

    public PublicationKey()
    {
        
    }
}
