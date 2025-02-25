using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.PostAggregate;
using Sober.Domain.Aggregates.PostAggregate.Entities;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Posts.Commands;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ErrorOr<Post>>
{
    private readonly IPostRepository _postRepository;

    public CreatePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<ErrorOr<Post>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;        

        // 1. Create Post
        Post post = Post.Create(
            userId: UserId.Create(request.UserId),
            postTitle: request.PostTitle,
            postAbstract: request.PostAbstract,
            conclusion: request.Conclusion,
            readingMinutes: request.ReadingMinute,
            sections: request.Sections.ConvertAll(section => PostSection.Create(
                section.SectionTitle,
                section.SectionDescription,
                section.Items.ConvertAll(item => PostItem.Create(
                    item.ItemTitle,
                    item.ItemDescription,
                    item.ItemImage)),
                section.SectionImage)),
            topics: request.Topics.ConvertAll(topic => PostTopic.Create(
                UserId.Create(request.UserId),
                topic.TopicTitle)),
            request.PostImage);


        // 2. Persist into DB
        _postRepository.CreatePost(post);

        // 3. Return Post
        return post;
    }
}
