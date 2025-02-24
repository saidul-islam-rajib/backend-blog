using MediatR;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Topics.Queries.Query
{
    public record GetAllTopicQuery : IRequest<IEnumerable<Topic>>
    {
    }
}
