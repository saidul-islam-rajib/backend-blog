using MediatR;
using Sober.Domain.Aggregates.ProjectAggregates;

namespace Sober.Application.Pages.Projects.Queries;

public record GetAllProjectQuery : IRequest<IEnumerable<Project>>
{
}
