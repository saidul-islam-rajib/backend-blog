using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Commands;

public record CreateFeedbackCommand
(
    Guid FeedbackId,
    string Email,
    string Name,
    string Comment,
    string GuestIpAddress
    ) : IRequest<ErrorOr<Feedback>>;
