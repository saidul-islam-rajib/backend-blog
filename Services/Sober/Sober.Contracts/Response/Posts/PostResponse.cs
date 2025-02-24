namespace Sober.Contracts.Response.Posts
{
    public record PostResponse(
        Guid PostId,
        string PostTitle,
        string? PostImage,
        string PostAbstract,
        string? Conclusion,
        int ReadingMinute,
        List<PostSectionResponse> Sections,
        List<TopicResponse> TopicIds,
        string UserId,
        DateTime CreatedDateTime,
        DateTime UpdatedDateTime);

    public record PostSectionResponse(
        string SectionId,
        string SectionTitle,
        string SectionDescription,
        List<PostSectionItemResponse> Items);

    public record PostSectionItemResponse(
        string ItemId,
        string ItemTitle,
        string? ItemImage,
        string ItemDescription,
        string ItemImageLink);

    public record TopicResponse(
        string TopicId,
        string TopicTitle,
        string UserId);
}
