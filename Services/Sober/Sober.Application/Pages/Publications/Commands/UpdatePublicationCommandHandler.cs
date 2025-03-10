using ErrorOr;
using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PublicationAggregate;
using Sober.Domain.Aggregates.PublicationAggregate.Entities;

namespace Sober.Application.Pages.Publications.Commands;

class UpdatePublicationCommandHandler
    : IRequestHandler<UpdatePublicationCommand, ErrorOr<Publication>>
{
    private readonly IPublicationRepository _repository;
    private readonly IFileService _fileService;

    public UpdatePublicationCommandHandler(IPublicationRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }

    public async Task<ErrorOr<Publication>> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Publication publication = await _repository.GetPublicationByIdAsync(request.PublicationId);
        if (publication is null)
        {
            throw new EducationNotFoundException(request.PublicationId);
        }
        if (request.PublicationImage is not null)
        {
            _fileService.DeleteFileAsync(publication.PublicationImage);
        }

        publication.Title= request.Title ?? publication.Title;
        publication.PublicationImage= request.PublicationImage ?? publication.PublicationImage;
        publication.JournalName= request.JournalName ?? publication.JournalName;
        publication.Summary= request.Summary ?? publication.Summary;
        publication.Date = request.Date ?? publication.Date;

        if (request.Keys is not null)
        {
            publication.Keys.Clear();

            foreach (var requestSection in request.Keys)
            {
                var newSection = PublicationKey.Create(requestSection.Key);
                publication.Keys.Add(newSection);
            }
        }

        bool isUpdated = await _repository.UpdatePublicationAsync(publication);
        if (!isUpdated)
        {
            throw new FailedException("Failed to update publication!");
        }

        return publication;
    }
}
