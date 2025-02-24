using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Pages.Feedbacks.Commands;

public class CreateFeedbackCommandHandler
    : IRequestHandler<CreateFeedbackCommand, ErrorOr<Feedback>>
{
    private readonly IFeedbackRepository _repository;

    public CreateFeedbackCommandHandler(IFeedbackRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Feedback>> Handle(CreateFeedbackCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Create Feedback
        Feedback feedback = Feedback.Create(
            request.Email,
            request.Name,
            request.Comment,
            request.GuestIpAddress);

        // 2. Persist into DB
        _repository.CreateFeedback(feedback);

        // 3. Return feedback
        return feedback;
    }
}
