using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PublicationAggregate;

namespace Sober.Application.Pages.Publications.Commands;

public class DeletePublicationCommandHandler
    : IRequestHandler<DeletePublicationCommand, bool>
{
    private readonly IPublicationRepository _publicationRepository;
    private readonly IFileService _fileService;

    public DeletePublicationCommandHandler(IPublicationRepository publicationRepository, IFileService fileService)
    {
        _publicationRepository = publicationRepository;
        _fileService = fileService;
    }
    public async Task<bool> Handle(DeletePublicationCommand request, CancellationToken cancellationToken)
    {
        Publication education = await _publicationRepository.GetPublicationByIdAsync(request.publicationId);
        if (education is null)
        {
            throw new EducationNotFoundException(request.publicationId);
        }

        bool isDeleted = _publicationRepository.DeletePublication(request.publicationId);
        if (isDeleted && education.PublicationImage is not null)
        {
            _fileService.DeleteFileAsync(education.PublicationImage);
        }

        return isDeleted;
    }
}
