using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.FeedbackAggregate;
using Sober.Domain.Aggregates.FeedbackAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories;

public class FeedbackRepository : IFeedbackRepository
{
    private readonly BlogDbContext _blogDbContext;

    public FeedbackRepository(BlogDbContext blogDbContext)
    {
        _blogDbContext = blogDbContext;
    }

    public void CreateFeedback(Feedback feedback)
    {
        _blogDbContext.Add(feedback);
        _blogDbContext.SaveChangesAsync();
    }

    public bool DeleteFeedback(Guid feedbackId)
    {
        var feedback = _blogDbContext.Feedbacks.Find(new FeedbackId(feedbackId));
        if (feedback is null)
        {
            return false;
        }
        _blogDbContext.Feedbacks.Remove(feedback);
        _blogDbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
    {
        IEnumerable<Feedback> response = await _blogDbContext.Feedbacks
            .AsNoTracking().ToListAsync();
        return response;
    }

    public async Task<Feedback> GetFeedbackByIdAsync(Guid feedbackId)
    {
        var response = await _blogDbContext.Feedbacks
                .FirstOrDefaultAsync(edu => edu.Id.Equals(new FeedbackId(feedbackId)));

        return response;
    }

    public async Task<bool> UpdateFeedbackAsync(Feedback feedback)
    {
        _blogDbContext.Feedbacks.Update(feedback);
        await _blogDbContext.SaveChangesAsync();
        return true;
    }
}
