namespace Sober.Contracts.Response.Comments
{
    public record CommentResponse(
        Guid CommentId,
        string PostId,
        string PostTitle,
        string Name,
        string Comments,
        DateTime date);
}
