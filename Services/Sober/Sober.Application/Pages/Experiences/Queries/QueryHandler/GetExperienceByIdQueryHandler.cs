using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Experiences.Queries.Query;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Queries.QueryHandler;

public class GetExperienceByIdQueryHandler
    : IRequestHandler<GetExperienceByIdQuery, Experience>
{
    private readonly IExperienceRepository _experienceRepository;

    public GetExperienceByIdQueryHandler(IExperienceRepository experienceRepository)
    {
        _experienceRepository = experienceRepository;
    }

    public async Task<Experience> Handle(GetExperienceByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _experienceRepository.GetExperienceByIdAsync(request.experienceId);
        return response;
    }
}
