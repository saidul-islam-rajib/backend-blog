using ErrorOr;
using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.Entities;

namespace Sober.Application.Pages.Educations.Commands;

public class UpdateEducationCommandHandler
    : IRequestHandler<UpdateEducationCommand, ErrorOr<Education>>
{
    private readonly IEducationRepository _educationRepository;
    private readonly IFileService _fileService;

    public UpdateEducationCommandHandler(IEducationRepository educationRepository, IFileService fileService)
    {
        _educationRepository = educationRepository;
        _fileService = fileService;
    }

    public async Task<ErrorOr<Education>> Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Education education = await _educationRepository.GetEducationByIdAsync(request.EducationId);
        if(education is null)
        {
            throw new EducationNotFoundException(request.EducationId);
        }
        if(request.InstituteLogo is not null)
        {
            _fileService.DeleteFileAsync(education.InstituteLogo);
        }

        education.InstituteName = request.InstituteName ?? education.InstituteName;
        education.InstituteLogo = request.InstituteLogo ?? education.InstituteLogo;
        education.Department = request.Department ?? education.Department;
        education.IsCurrentStudent = request.IsCurrentStudent ?? education.IsCurrentStudent;
        education.StartDate = request.StartDate ?? education.StartDate;
        education.EndDate = request.EndDate ?? education.EndDate;
        
        if(request.EducationSection is not null)
        {
            foreach (var requestSection in request.EducationSection)
            {
                var existingSection = education.EducationSection.FirstOrDefault(x => x.SectionDescription == requestSection.SectionDescription);

                if (existingSection is null)
                {
                    var newSection = EducationSection.Create(requestSection.SectionDescription);
                    education.EducationSection.Add(newSection);
                }
            }
        }

        bool isUpdated = await _educationRepository.UpdateEducationAsync(education);
        if (!isUpdated)
        {
            throw new FailedException("Failed to update education!");
        }

        return education;
    }
}
