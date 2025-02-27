using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Commands
{
    public record CreateEducationCommand(
        Guid UserId,
        string InstituteName,
        string InstituteLogo,
        string Department,
        bool IsCurrentStudent,
        List<EducationSectionCommand> EducationSection,
        DateTime StartDate,
        DateTime? EndDate) : IRequest<ErrorOr<Education>>;

    public record EducationSectionCommand(string SectionDescription);
}
