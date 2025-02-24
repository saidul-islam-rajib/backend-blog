using MediatR;
using Sober.Application.Interfaces;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.Tags.Queries;

public class GetTagsWithTopicsQueryHandler
    : IRequestHandler<GetTagsWithTopicsQuery, IEnumerable<TagWithTopicResponse>>
{
    private readonly ITagRepository _tagRepository;

    public GetTagsWithTopicsQueryHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<IEnumerable<TagWithTopicResponse>> Handle(GetTagsWithTopicsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var response = await _tagRepository.GetTagWithTopicAsync(cancellationToken);
        return response;
    }
}
