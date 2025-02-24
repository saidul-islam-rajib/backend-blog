using BuildingBlocks.Exceptions;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Commands;

public class DeleteFeedbackCommandHandler : IRequestHandler<DeleteFeedbackCommand, bool>
{
    private readonly IFeedbackRepository _feedbackRepository;

    public DeleteFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<bool> Handle(DeleteFeedbackCommand request, CancellationToken cancellationToken)
    {
        Feedback feedback = await _feedbackRepository.GetFeedbackByIdAsync(request.feedbackId);
        if (feedback is null)
        {
            throw new NotFoundException($"Feedback with ID {request.feedbackId} not found.");
        }
        bool isDeleted = _feedbackRepository.DeleteFeedback(request.feedbackId);

        return isDeleted;
    }
}
