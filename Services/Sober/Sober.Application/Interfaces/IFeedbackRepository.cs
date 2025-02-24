using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Application.Interfaces;

public interface IFeedbackRepository
{
    void CreateFeedback(Feedback feedback);
    Task<bool> UpdateFeedbackAsync(Feedback feedback);
    bool DeleteFeedback(Guid feedbackId);
    Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
    Task<Feedback> GetFeedbackByIdAsync(Guid feedbackId);
}
