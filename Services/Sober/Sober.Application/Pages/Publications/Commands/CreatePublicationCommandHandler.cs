using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.PublicationAggregate.Entities;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.Publications.Commands;

public class CreatePublicationCommandHandler
    : IRequestHandler<CreatePublicationCommand, ErrorOr<Publication>>
{
    private readonly IPublicationRepository _repository;

    public CreatePublicationCommandHandler(IPublicationRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Publication>> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Create Publication
        Publication publication = Publication.Create(
            request.Title,
            request.Summary,
            UserId.Create(request.UserId),
            request.Keys.ConvertAll(
                key => PublicationKey.Create(key.Key)),
            request?.JournalName,
            request?.Date);

        // 2. Persist into DB
        _repository.AddPublication(publication);

        // 3. Return Publications
        return publication;
    }
}
