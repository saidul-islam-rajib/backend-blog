using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Experiences.Queries.Query;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Queries.QueryHandler
{
    public class GetExperienceQueryHandler : IRequestHandler<GetExperienceQuery, IEnumerable<Experience>>
    {
        private readonly IExperienceRepository _repository;

        public GetExperienceQueryHandler(IExperienceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Experience>> Handle(GetExperienceQuery request, CancellationToken cancellationToken)
        {
            var response = await _repository.GetAllExperienceAsync();
            return response;
        }
    }
}
