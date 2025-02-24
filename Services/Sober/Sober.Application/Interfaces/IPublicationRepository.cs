using Sober.Domain.Aggregates.PublicationAggregate;

namespace Sober.Application.Interfaces;

public interface IPublicationRepository
{
    void AddPublication(Publication publication);
    Task<bool> UpdatePublicationAsync(Publication publication);
    bool DeletePublication(Guid publicationId);
    Task<IEnumerable<Publication>> GetAllPublicationAsync();
    Task<Publication?> GetPublicationByIdAsync(Guid publicationId);
}
