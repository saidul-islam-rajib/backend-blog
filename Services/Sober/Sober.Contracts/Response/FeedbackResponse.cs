namespace Sober.Contracts.Response;

public record FeedbackResponse(
    Guid FeedbackId,
    string Email,
    string? Name,
    string? Comment,
    string? GuestIpAddress);
public record UpdateFeedbackResponse(
    Guid FeedbackId,
    string Email,
    string? Name,
    string? Comment,
    string? GuestIpAddress);