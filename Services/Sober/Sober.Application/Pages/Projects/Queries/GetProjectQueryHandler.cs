using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ProjectAggregates;

namespace Sober.Application.Pages.Projects.Queries;

public class GetProjectQueryHandler : IRequestHandler<GetAllProjectQuery, IEnumerable<Project>>
{
    private readonly IProjectRepository _repository;

    public GetProjectQueryHandler(IProjectRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Project>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllProjectAsync();
        return response;
    }
}
