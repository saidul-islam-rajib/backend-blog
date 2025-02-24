using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Queries;

public class GetFeedbackQueryHandler : IRequestHandler<GetFeedbackQuery, IEnumerable<Feedback>>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public GetFeedbackQueryHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<IEnumerable<Feedback>> Handle(GetFeedbackQuery request, CancellationToken cancellationToken)
    {
        var response = await _feedbackRepository.GetAllFeedbackAsync();
        return response;
    }
}
