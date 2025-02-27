using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Commands;

public record UpdateEducationCommand(
    Guid UserId,
    Guid EducationId,
    string? InstituteName,
    string? InstituteLogo,
    string? Department,
    bool? IsCurrentStudent,
    List<UpdateEducationSectionCommand>? EducationSection,
    DateTime? StartDate,
    DateTime? EndDate) : IRequest<ErrorOr<Education>>;

public record UpdateEducationSectionCommand(string? SectionDescription);


