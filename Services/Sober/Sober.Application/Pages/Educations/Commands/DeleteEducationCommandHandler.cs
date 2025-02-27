using MediatR;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.Educations.Commands;

public class DeleteEducationCommandHandler
    : IRequestHandler<DeleteEducationCommand, bool>
{
    private readonly IEducationRepository _educationRepository;

    public DeleteEducationCommandHandler(IEducationRepository educationRepository)
    {
        _educationRepository = educationRepository;
    }

    public async Task<bool> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
    {
        Education education = await _educationRepository.GetEducationByIdAsync(request.educationId);
        if(education is null)
        {
            throw new EducationNotFoundException(request.educationId);
        }
        bool isDeleted = _educationRepository.DeleteEducation(request.educationId);

        return isDeleted;
    }
}
