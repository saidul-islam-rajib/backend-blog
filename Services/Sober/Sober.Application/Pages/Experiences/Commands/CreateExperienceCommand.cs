using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Commands
{
    public record CreateExperienceCommand(
        Guid UserId,
        string CompanyName,
        string ShortName,
        string CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        bool IsFullTimeEmployee,
        List<ExperienceSectionCommand> ExperienceSection,
        DateTime StartDate,
        DateTime EndDate
        ) : IRequest<ErrorOr<Experience>>;

    public record ExperienceSectionCommand(string sectionDescription);
}
