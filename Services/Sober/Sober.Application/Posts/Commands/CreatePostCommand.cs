using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.PostAggregate;

namespace Sober.Application.Posts.Commands
{
    public record CreatePostCommand(
        Guid UserId,
        string PostTitle,
        string PostImage,
        string PostAbstract,
        string? Conclusion,
        int ReadingMinute,
        List<PostSectionCommand> Sections,
        List<TopicCommand> Topics
        ) : IRequest<ErrorOr<Post>>;

    public record PostSectionCommand(
        string SectionTitle,
        string SectionDescription,
        List<PostSectionItemCommand> Items);

    public record PostSectionItemCommand(
        string ItemTitle,
        string ItemImage,
        string ItemDescription);

    public record TopicCommand(
        Guid UserId,
        string TopicTitle);
}
