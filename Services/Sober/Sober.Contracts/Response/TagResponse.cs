namespace Sober.Contracts.Response;

public record TagResponse(Guid TagId, string TagName, Guid TopicId);
public record TagWithTopicResponse(
    Guid TopicId,
    string TopicName,
    List<TagInformation> TagInformation);

public record TagInformation(Guid TagId, string TagName);
