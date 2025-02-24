using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Queries;

public record GetTagByIdQuery(Guid tagId) : IRequest<Tag>
{
}

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, Tag>
{
    private readonly ITagRepository _tagRepository;

    public GetTagByIdQueryHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Tag> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _tagRepository.GetTagByIdAsync(request.tagId);
        return response;
    }
}
