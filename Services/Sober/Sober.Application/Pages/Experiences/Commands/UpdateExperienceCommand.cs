using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Commands;

public record UpdateExperienceCommand(
    Guid UserId,
    Guid ExperienceId,
    string CompanyName,
    string ShortName,
    string CompanyLogo,
    string Designation,
    bool IsCurrentEmployee,
    bool IsFullTimeEmployee,
    List<UpdateExperienceSectionCommand> ExperienceSection,
    DateTime StartDate,
    DateTime? EndDate) : IRequest<ErrorOr<Experience>>;

public record UpdateExperienceSectionCommand(Guid SectionId, string SectionDescription);
