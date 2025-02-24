using Microsoft.EntityFrameworkCore;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.PublicationAggregate.ValueObjects;

namespace Sober.Infrastructure.Persistence.Repositories;

public class PublicationRepository : IPublicationRepository
{
    private readonly BlogDbContext _dbContext;

    public PublicationRepository(BlogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void AddPublication(Publication publication)
    {
        _dbContext.Add(publication);
        _dbContext.SaveChangesAsync();
    }

    public bool DeletePublication(Guid publicationId)
    {
        var publication = _dbContext.Publications.Find(new PublicationId(publicationId));
        if(publication is null)
        {
            return false;
        }

        _dbContext.Publications.Remove(publication);
        _dbContext.SaveChanges();
        return true;
    }

    public async Task<IEnumerable<Publication>> GetAllPublicationAsync()
    {
        var response = await _dbContext.Publications.AsNoTracking().OrderBy(o => o.Date).ToListAsync();
        return response;
    }

    public async Task<Publication?> GetPublicationByIdAsync(Guid publicationId)
    {
        var response = await _dbContext.Publications
                        .Include(publication => publication.Keys)
                        .FirstOrDefaultAsync(p => p.Id.Equals(new PublicationId(publicationId)));

        return response;
    }

    public async Task<bool> UpdatePublicationAsync(Publication publication)
    {
        var existingPublication = await _dbContext.Publications
                        .Include(p => p.Keys)
                        .FirstOrDefaultAsync(p => p.Id == publication.Id);

        if(existingPublication is null)
        {
            return false;
        }

        // Update properties of the existing publicatoin
        existingPublication.Title = publication.Title;
        existingPublication.Summary = publication.Summary;
        existingPublication.JournalName = publication.JournalName;
        existingPublication.Date = publication.Date;

        existingPublication.Keys.Clear();
        foreach(var key in existingPublication.Keys)
        {
            existingPublication.Keys.Add(key);
        }

        await _dbContext.SaveChangesAsync();
        return true;

    }
}
