using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.AdditionalSkillAggregate;
using Sober.Domain.Aggregates.AdditionalSkillAggregate.Entities;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.AdditionalSkills.Commands;

public class CreateAdditionalSkillCommandHandler
    : IRequestHandler<CreateAdditionalSkillCommand, ErrorOr<AdditionalSkill>>
{
    private readonly IAdditionalSkillRepository _additionalSkillRepository;

    public CreateAdditionalSkillCommandHandler(IAdditionalSkillRepository additionalSkillRepository)
    {
        _additionalSkillRepository = additionalSkillRepository;
    }

    public async Task<ErrorOr<AdditionalSkill>> Handle(CreateAdditionalSkillCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        // 1. Create Additional Skill
        AdditionalSkill skills = AdditionalSkill.Create(
            request.Title,
            UserId.Create(request.UserId),
            request.Keys.ConvertAll(
                key => AdditionalKey.Create(key.Key)),
            request?.Image);

        // 2. Persist into DB
        _additionalSkillRepository.AddAdditionalSkillAsync(skills);

        // 3. Return Additional Skill
        return skills;
    }
}
