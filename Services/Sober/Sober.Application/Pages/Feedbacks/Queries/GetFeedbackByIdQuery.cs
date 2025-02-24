using MediatR;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Queries;

public record GetFeedbackByIdQuery(Guid FeedbackId) : IRequest<Feedback>;
