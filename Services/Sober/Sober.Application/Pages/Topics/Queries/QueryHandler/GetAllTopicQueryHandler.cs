using MediatR;
using Sober.Application.Interfaces;
using Sober.Application.Pages.Topics.Queries.Query;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Topics.Queries.QueryHandler
{
    public class GetAllTopicQueryHandler : IRequestHandler<GetAllTopicQuery, IEnumerable<Topic>>
    {
        private readonly ISkillRepository _skillRepository;

        public GetAllTopicQueryHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<IEnumerable<Topic>> Handle(GetAllTopicQuery request, CancellationToken cancellationToken)
        {
            var response = await _skillRepository.GetAllSkillAsync();
            return response;
        }
    }
}
