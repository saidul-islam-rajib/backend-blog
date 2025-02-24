namespace Sober.Contracts.Response;

public record ProjectResponse(
    Guid ProjectId,
    Guid PostId,     
    string ProjectTitle,
    string ProjectSummary,
    string ProjectSrcLink,
    string ProjectImage,
    List<ProjectSectionResponse> ProjectSection,
    DateTime DisplayDate,
    DateTime StartDate,
    DateTime EndDate);

public record ProjectSectionResponse(
    string ProjectSectionId,
    string TopicId,
    string TopicName,
    List<ProjectTagResponse> ProjectTags);

public record ProjectTagResponse(
    string ProjectTagId,
    string TagId,
    string ProjectTagName);
