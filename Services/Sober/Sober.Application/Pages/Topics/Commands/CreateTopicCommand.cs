using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Topics.Commands
{
    public record CreateTopicCommand(string skillName) : IRequest<ErrorOr<Topic>>;
}
