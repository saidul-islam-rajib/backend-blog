using Microsoft.AspNetCore.Http;

namespace Sober.Contracts.Request.Posts
{
    public record PostRequest(
        string PostTitle,
        IFormFile PostImage,
        string PostAbstract,
        string Conclusion,
        int ReadingMinute,
        List<PostSectionRequest> Sections,
        List<TopicRequest> Topics);

    public record PostSectionRequest(
        string SectionTitle,
        string SectionDescription,
        List<PostSectionItemRequest> Items);

    public record PostSectionItemRequest(
        string ItemTitle,
        IFormFile ItemImage,
        string ItemDescription);

    public record TopicRequest(
        string TopicTitle,
        string UserId);

}
