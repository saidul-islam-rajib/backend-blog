namespace Sober.Contracts.Request
{
    public record PublicationRequest(
        string Title,        
        string Summary,
        List<PublicationKeyRequest> Keys,
        string JournalName,
        DateTime Date
        );

    public record PublicationKeyRequest(string Key);
}
