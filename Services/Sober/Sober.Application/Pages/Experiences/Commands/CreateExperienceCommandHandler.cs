using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.ExperienceAggregate;
using Sober.Domain.Aggregates.ExperienceAggregate.Entities;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.Experiences.Commands
{
    public class CreateExperienceCommandHandler : IRequestHandler<CreateExperienceCommand, ErrorOr<Experience>>
    {
        private readonly IExperienceRepository _repository;

        public CreateExperienceCommandHandler(IExperienceRepository repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<Experience>> Handle(CreateExperienceCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;            

            // 1. Create Experience
            Experience experience = Experience.Create(
                UserId.Create(request.UserId),
                request.CompanyName,
                request.ShortName,
                request.CompanyLogo,
                request.Designation,
                request.IsCurrentEmployee,
                request.IsFullTimeEmployee,
                request.ExperienceSection.ConvertAll(
                    section => ExperienceSection.Create(section.sectionDescription)),
                request.StartDate,
                request.EndDate
                );

            
            // 2. Persist into DB
            _repository.AddExperience(experience);

            // 3. Return Experience
            return experience;
        }
    }
}
