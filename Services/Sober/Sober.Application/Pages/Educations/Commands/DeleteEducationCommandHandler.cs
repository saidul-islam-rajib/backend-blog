using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Commands;

public class DeleteEducationCommandHandler
    : IRequestHandler<DeleteEducationCommand, bool>
{
    private readonly IEducationRepository _educationRepository;
    private readonly IFileService _fileService;

    public DeleteEducationCommandHandler(IEducationRepository educationRepository, IFileService fileService)
    {
        _educationRepository = educationRepository;
        _fileService = fileService;
    }

    public async Task<bool> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
    {
        Education education = await _educationRepository.GetEducationByIdAsync(request.educationId);
        if(education is null)
        {
            throw new EducationNotFoundException(request.educationId);
        }

        bool isDeleted = _educationRepository.DeleteEducation(request.educationId);
        if (isDeleted && education.InstituteLogo is not null)
        {
            _fileService.DeleteFileAsync(education.InstituteLogo);
        }

        return isDeleted;
    }
}
