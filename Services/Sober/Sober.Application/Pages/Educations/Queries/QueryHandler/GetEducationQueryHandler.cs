using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Educations.Queries.Query;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Queries.QueryHandler
{
    public class GetEducationQueryHandler
        : IRequestHandler<GetEducationQuery, IEnumerable<Education>>
    {
        private readonly IEducationRepository _educationRepository;

        public GetEducationQueryHandler(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<IEnumerable<Education>> Handle(GetEducationQuery request, CancellationToken cancellationToken)
        {
            var response = await _educationRepository.GetAllEducations();
            return response;
        }
    }
}
