using MediatR;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Queries.Query
{
    public record GetEducationQuery() : IRequest<IEnumerable<Education>>;
}
