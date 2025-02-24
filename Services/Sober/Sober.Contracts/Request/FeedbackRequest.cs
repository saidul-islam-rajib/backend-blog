namespace Sober.Contracts.Request;

public record FeedbackRequest(string Email, string? Name, string? Comment, string? GuestIpAddress);
public record UpdateFeedbackRequest(string Email, string? Name, string? Comment, string? GuestIpAddress);
