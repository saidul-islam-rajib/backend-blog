using ErrorOr;
using MediatR;
using Sober.Application.CustomeExceptions.NotFoundExceptions;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Commands;

public class UpdateFeedbackCommandHandler : IRequestHandler<UpdateFeedbackCommand, ErrorOr<Feedback>>
{
    private readonly IFeedbackRepository _feedbackRepository;
    public UpdateFeedbackCommandHandler(IFeedbackRepository feedbackRepository)
    {
        _feedbackRepository = feedbackRepository;
    }

    public async Task<ErrorOr<Feedback>> Handle(UpdateFeedbackCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var feedback = await _feedbackRepository.GetFeedbackByIdAsync(request.FeedbackId);
        if (feedback is null)
        {
            throw new TagNotFoundException(request.FeedbackId);
        }

        feedback.Email = request.Email;
        feedback.Name = request.Name;
        feedback.Comment = request.Comment;
        feedback.GuestIpAddress = request.GuestIpAddress;

        var isUpdated = await _feedbackRepository.UpdateFeedbackAsync(feedback);
        if (!isUpdated)
        {
            throw new TagFailedException("Failed to update!");
        }

        return feedback;
    }
}
