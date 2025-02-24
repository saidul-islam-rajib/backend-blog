using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.SkillAggregate;

namespace Sober.Application.Pages.Topics.Commands
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, ErrorOr<Topic>>
    {
        private readonly ISkillRepository _skillRepository;

        public CreateTopicCommandHandler(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public async Task<ErrorOr<Topic>> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            Topic skill = Topic.Create(request.skillName);
            _skillRepository.CreateSkill(skill);

            return skill;
        }
    }
}
