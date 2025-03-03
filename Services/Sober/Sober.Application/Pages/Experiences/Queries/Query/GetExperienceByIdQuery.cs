using MediatR;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Application.Pages.Experiences.Queries.Query;

public record GetExperienceByIdQuery(Guid experienceId) : IRequest<Experience>;
