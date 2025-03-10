using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Publications.Queries.Query;
using Sober.Domain.Aggregates.PublicationAggregate;

namespace Sober.Application.Pages.Publications.Queries.QueryHandler;

public class GetPublicationByIdQueryHandler
    : IRequestHandler<GetPublicationByIdQuery, Publication>
{
    private readonly IPublicationRepository _publicationRepository;

    public GetPublicationByIdQueryHandler(IPublicationRepository publicationRepository)
    {
        _publicationRepository = publicationRepository;
    }

    public async Task<Publication> Handle(GetPublicationByIdQuery request, CancellationToken cancellationToken)
    {
        Publication response = await _publicationRepository.GetPublicationByIdAsync(request.publiationId);
        return response;
    }
}
