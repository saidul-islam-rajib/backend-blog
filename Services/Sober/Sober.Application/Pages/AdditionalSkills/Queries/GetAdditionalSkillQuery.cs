using MediatR;
using Sober.Contracts.Response;

namespace Sober.Application.Pages.AdditionalSkills.Queries;

public record GetAdditionalSkillQuery()
    : IRequest<IEnumerable<AdditionalSkillResponse>>
{
}
