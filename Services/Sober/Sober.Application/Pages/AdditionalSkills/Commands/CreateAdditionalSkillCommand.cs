using ErrorOr;
using MediatR;
using Sober.Domain.Aggregates.AdditionalSkillAggregate;

namespace Sober.Application.Pages.AdditionalSkills.Commands;

public record CreateAdditionalSkillCommand(
    Guid UserId,
    string Title,
    string Image,
    List<AdditionalSkillKeyCommand> Keys)
    : IRequest<ErrorOr<AdditionalSkill>>;

public record AdditionalSkillKeyCommand(string Key);
