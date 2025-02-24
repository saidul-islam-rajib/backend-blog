using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Queries;

public class GetAllTagQueryHandler
    : IRequestHandler<GetAllTagQuery, IEnumerable<Tag>>
{
    private readonly ITagRepository _repository;

    public GetAllTagQueryHandler(ITagRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Tag>> Handle(GetAllTagQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var response = await _repository.GetAllTagAsync();
        return response;
    }
}
