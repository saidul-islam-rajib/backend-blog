using Microsoft.AspNetCore.Http;

namespace Sober.Contracts.Request;

public record EducationRequest(
    string InstituteName,
    IFormFile InstituteLogo,
    string Department,
    bool IsCurrentStudent,
    List<EducationSectionRequest> EducationSection,
    DateTime StartDate,
    DateTime? EndDate);

public record EducationSectionRequest(string SectionDescription);

public record UpdateEducationRequest(
    string? InstituteName,
    IFormFile? InstituteLogo,
    string? Department,
    bool? IsCurrentStudent,
    List<UpdateEducationSectionRequest>? EducationSection,
    DateTime? StartDate,
    DateTime? EndDate);
public record UpdateEducationSectionRequest(string? SectionDescription);
