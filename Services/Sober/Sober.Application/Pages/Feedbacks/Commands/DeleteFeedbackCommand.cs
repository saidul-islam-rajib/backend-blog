using MediatR;

namespace Sober.Application.Pages.Feedbacks.Commands;

public record DeleteFeedbackCommand(Guid feedbackId) : IRequest<bool>;