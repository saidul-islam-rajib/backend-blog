using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Commands;

public class DeleteExperienceCommandHandler : IRequestHandler<DeleteExperienceCommand, bool>
{
    private readonly IExperienceRepository _experienceRepository;
    private readonly IFileService _fileService;

    public DeleteExperienceCommandHandler(IExperienceRepository experienceRepository, IFileService fileService)
    {
        _experienceRepository = experienceRepository;
        _fileService = fileService;
    }

    public async Task<bool> Handle(DeleteExperienceCommand request, CancellationToken cancellationToken)
    {
        Experience experience =  await _experienceRepository.GetExperienceByIdAsync(request.experienceId);
        if(experience is null)
        {
            throw new ExperienceNotFoundException(request.experienceId);
        }
        bool isDeleted = _experienceRepository.DeleteExperience(request.experienceId);
        if (isDeleted)
        {
            _fileService.DeleteFileAsync(experience.CompanyLogo);
        }

        return isDeleted;
    }
}
