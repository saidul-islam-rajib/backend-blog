using ErrorOr;
using MediatR;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.Entities;
using Sober.Domain.Aggregates.ExperienceAggregate.ValueObjects;

namespace Sober.Application.Pages.Experiences.Commands;

public class UpdateExperienceCommandHandler : IRequestHandler<UpdateExperienceCommand, ErrorOr<Experience>>
{
    private readonly IExperienceRepository _experienceRepository;

    public UpdateExperienceCommandHandler(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public async Task<ErrorOr<Experience>> Handle(UpdateExperienceCommand request, CancellationToken cancellationToken)
    {
        var existingExperience = await _experienceRepository.GetExperienceByIdAsync(request.ExperienceId);
        if (existingExperience is null)
        {
            throw new ExperienceNotFoundException(request.ExperienceId);
        }

        // Update properties dynamically
        existingExperience.CompanyName = UpdateIfChanged(existingExperience.CompanyName, request.CompanyName);
        existingExperience.ShortName = UpdateIfChanged(existingExperience.ShortName, request.ShortName);
        existingExperience.CompanyLogo = UpdateIfChanged(existingExperience.CompanyLogo, request.CompanyLogo);
        existingExperience.Designation = UpdateIfChanged(existingExperience.Designation, request.Designation);
        existingExperience.IsCurrentEmployee = UpdateIfChanged(existingExperience.IsCurrentEmployee, request.IsCurrentEmployee);
        existingExperience.IsFullTimeEmployee = UpdateIfChanged(existingExperience.IsFullTimeEmployee, request.IsFullTimeEmployee);
        existingExperience.StartDate = UpdateIfChanged(existingExperience.StartDate, request.StartDate);

        if (request.EndDate.HasValue)
        {
            existingExperience.EndDate = UpdateIfChanged(existingExperience.EndDate, request.EndDate.Value);
        }

        // Update experience sections
        UpdateExperienceSections(existingExperience.ExperienceSection, request.ExperienceSection);

        // Persist changes to the repository
        bool isUpdated = await _experienceRepository.UpdateExperienceAsync(existingExperience);
        if (!isUpdated)
        {
            return Error.Failure("Experience.UpdateFailed", "Failed to update the experience.");
        }

        return existingExperience;
    }

    private T? UpdateIfChanged<T>(T? existingValue, T? newValue) where T : IEquatable<T>
    {
        if(newValue is null)
        {
            return existingValue;
        }

        return !EqualityComparer<T>.Default.Equals(existingValue, newValue) ? newValue : existingValue;
    }

    private void UpdateExperienceSections(
    ICollection<ExperienceSection> existingSections,
    List<UpdateExperienceSectionCommand> newSections)
    {
        foreach (var sectionCommand in newSections)
        {
            // Find the existing section by SectionDescription
            var existingSection = existingSections.FirstOrDefault(s => s.Id.Value == sectionCommand.SectionId);
            //var existingSection = existingSections.FirstOrDefault(s => s.SectionDescription.Equals(sectionCommand.SectionDescription, StringComparison.Ordinal));

            if (existingSection is not null)
            {
                // If found, update the SectionDescription only if different (though it's unlikely since we matched on it)
                if (!existingSection.SectionDescription.Equals(sectionCommand.SectionDescription, StringComparison.Ordinal))
                {
                    existingSection.SectionDescription = sectionCommand.SectionDescription;
                }
            }
            else
            {
                // If no matching section is found, create a new one
                var newSection = ExperienceSection.Create(sectionCommand.SectionDescription);
                existingSections.Add(newSection);
            }
        }
    }
}


