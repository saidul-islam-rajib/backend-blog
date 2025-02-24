using Microsoft.AspNetCore.Http;

namespace Sober.Contracts.Request
{
    public record ExperienceRequest(
        string CompanyName,
        string ShortName,
        IFormFile CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        bool IsFullTimeEmployee,
        List<ExperienceSectionRequest> ExperienceSection,
        DateTime StartDate,
        DateTime EndDate);

    public record ExperienceSectionRequest(string SectionDescription);
}
