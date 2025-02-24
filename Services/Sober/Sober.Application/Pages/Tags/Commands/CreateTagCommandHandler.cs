using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.SkillAggregate.ValueObjects;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Commands;

public class CreateTagCommandHandler
    : IRequestHandler<CreateTagCommand, ErrorOr<Tag>>
{
    private readonly ITagRepository _repository;

    public CreateTagCommandHandler(ITagRepository repository)
    {
        _repository = repository;
    }

    public async Task<ErrorOr<Tag>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        Tag tag = Tag.Create(request.TagName, TopicId.Create(request.TopicId));
        _repository.AddTag(tag);
        return tag;
    }
}
