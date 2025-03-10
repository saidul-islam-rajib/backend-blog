using Microsoft.AspNetCore.Http;

namespace Sober.Contracts.Request
{
    public record PublicationRequest(
        string Title,
        IFormFile PublicationImage,
        string Summary,
        List<PublicationKeyRequest> Keys,
        string JournalName,
        DateTime Date
        );
    public record UpdatePublicationRequest(
        string Title,
        IFormFile PublicationImage,
        string Summary,
        List<UpdatePublicationKeyRequest> Keys,
        string JournalName,
        DateTime Date
        );

    public record PublicationKeyRequest(string Key);
    public record UpdatePublicationKeyRequest(string Key);
}
