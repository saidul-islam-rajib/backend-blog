using Sober.Domain.Aggregates.PublicationAggregate.Entities;
using Sober.Domain.Aggregates.PublicationAggregate.ValueObjects;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.PublicationAggregate;

public sealed class Publication : AggregateRoot<PublicationId>
{
    private readonly List<PublicationKey> _keys = new();
    public string Title { get; set; } = null!;
    public string? JournalName { get; set; }
    public string Summary { get; set; } = null!;
    public DateTime? Date { get; set; }
    public UserId UserId { get; private set; } = null!;
    public ICollection<PublicationKey> Keys => _keys.AsReadOnly();

    private Publication(
        PublicationId publicationId,        
        string title,
        string summary,
        UserId userId,
        List<PublicationKey> keys,
        string? journalName,
        DateTime? date)
        : base(publicationId)
    {        
        Title = title;        
        Summary = summary;
        UserId = userId;
        _keys = keys;
        JournalName = journalName;
        Date = date;        
    }

    public static Publication Create(string title, string summary, UserId userId, List<PublicationKey> keys, string? journalName, DateTime? date)
    {
        Publication response = new Publication(PublicationId.CreateUnique(), title, summary, userId, keys, journalName, date);
        return response;
    }

    public Publication()
    {
        
    }
}
