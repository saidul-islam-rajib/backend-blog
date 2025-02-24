namespace Sober.Contracts.Response
{
    public record PublicationResponse(
        Guid PublicationId,
        string UserId,
        string Title,
        string PublicationImage,
        string Summary,
        List<PublicationKeyResponse> Keys,
        string JournalName,
        DateTime Date);

    public record PublicationKeyResponse(string PublicationKeyId, string Key);
}
