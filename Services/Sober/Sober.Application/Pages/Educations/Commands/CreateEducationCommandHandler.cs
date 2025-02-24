using ErrorOr;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;
using Sober.Domain.Aggregates.EducationAggregate.Entities;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;

namespace Sober.Application.Pages.Educations.Commands
{
    public class CreateEducationCommandHandler
        : IRequestHandler<CreateEducationCommand, ErrorOr<Education>>
    {
        private readonly IEducationRepository _educationRepository;

        public CreateEducationCommandHandler(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<ErrorOr<Education>> Handle(CreateEducationCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            Education education = Education.Create(
                UserId.Create(request.UserId),
                request.InstituteName,
                request.InstituteLogo,
                request.Department,
                request.IsCurrentStudent,
                request.EducationSection.ConvertAll(section => EducationSection.Create(section.SectionDescripton)),
                request.StartDate,
                request.EndDate);

            _educationRepository.AddEducation(education);
            return education;
        }
    }
}
