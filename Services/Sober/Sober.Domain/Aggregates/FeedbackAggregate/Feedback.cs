using Sober.Domain.Aggregates.FeedbackAggregate.ValueObjects;
using Sober.Domain.Common.Models;

namespace Sober.Domain.Aggregates.FeedbackAggregate;

public sealed class Feedback : AggregateRoot<FeedbackId>
{
    public string Email { get; set; } = null;
    public string? Name { get; set; }
    public string? Comment { get; set; }
    public string? GuestIpAddress { get; set; }

    private Feedback(FeedbackId id, string email, string? name, string? comment, string? guestIpAddress)
        : base(id)
    {
        Email = email;
        Name = name;
        Comment = comment;
        GuestIpAddress = guestIpAddress;
    }

    public static Feedback Create(string email, string? name, string? comment, string? guestIpAddress)
    {
        Feedback response = new Feedback(FeedbackId.CreateUnique(), email, name, comment, guestIpAddress);

        return response;
    }

    public Feedback()
    {
    }
}
