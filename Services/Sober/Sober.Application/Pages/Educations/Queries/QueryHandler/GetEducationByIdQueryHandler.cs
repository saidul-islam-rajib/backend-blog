using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Educations.Queries.Query;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Queries.QueryHandler;

public class GetEducationByIdQueryHandler : IRequestHandler<GetEducationByIdQuery, Education>
{
    private readonly IEducationRepository _educationRepository;

    public GetEducationByIdQueryHandler(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }

    public async Task<Education> Handle(GetEducationByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _educationRepository.GetEducationByIdAsync(request.educationId);
        return response;
    }
}
