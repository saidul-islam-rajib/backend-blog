namespace Sober.Contracts.Request
{
    public record ProjectRequest(
        Guid PostId,
        string ProjectTitle,
        string ProjectSummary,
        string ProjectSrcLink,
        string ProjectImage,
        List<ProjectTopicRequest> ProjectTopics,
        DateTime DisplayDate,
        DateTime StartDate,
        DateTime EndDate);

    public record ProjectTopicRequest(
        Guid TopicId,
        List<ProjectTopicTagRequest> ProjectTags
        );

    public record ProjectTopicTagRequest(Guid TagId);
}
