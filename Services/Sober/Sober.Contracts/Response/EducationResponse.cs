namespace Sober.Contracts.Response
{
    public record EducationResponse(
        Guid EducationId,
        string UserId,
        string InstituteName,
        string InstituteLogo,
        string Department,
        bool IsCurrentStudent,
        List<EducationSectionResponse> EducationSection,
        DateTime StartDate,
        DateTime EndDate);

    public record EducationSectionResponse(string EducationSectionId, string SectionDescription);
}
