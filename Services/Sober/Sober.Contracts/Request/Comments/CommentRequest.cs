namespace Sober.Contracts.Request.Comments
{
    public record CommentRequest(
        string PostId,
        string Name,
        string Comments);
}
