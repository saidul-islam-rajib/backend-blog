using MediatR;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Queries;

public record GetFeedbackQuery : IRequest<IEnumerable<Feedback>>
{
}
