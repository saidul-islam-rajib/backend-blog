using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Queries;

public class GetFeedbackByIdQueryHandler : IRequestHandler<GetFeedbackByIdQuery, Feedback>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public GetFeedbackByIdQueryHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<Feedback> Handle(GetFeedbackByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _feedbackRepository.GetFeedbackByIdAsync(request.FeedbackId);
        return response;
    }
}
