namespace Sober.Contracts.Response
{
    public record ExperienceResponse(
        Guid ExperienceId,
        string UserId,
        string CompanyName,
        string ShortName,
        string CompanyLogo,
        string Designation,
        bool IsCurrentEmployee,
        DateTime StartDate,
        DateTime EndDate,
        bool IsFullTimeEmployee,
        List<ExperienceSectionResponse> ExperienceSection,
        DateTime CreatedDate,
        DateTime UpdatedDate);

    public record ExperienceSectionResponse(string ExperienceSectionId, string SectionDescription);
}
