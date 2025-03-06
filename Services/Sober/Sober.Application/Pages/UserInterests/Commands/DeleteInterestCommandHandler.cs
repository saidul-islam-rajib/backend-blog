using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.InterestAggregates;

namespace Sober.Application.Pages.UserInterests.Commands;

public class DeleteInterestCommandHandler
    : IRequestHandler<DeleteInterestCommand, bool>
{
    private readonly IInterestRepository _interestRepository;
    private readonly IFileService _fileService;

    public DeleteInterestCommandHandler(IInterestRepository interestRepository, IFileService fileService)
    {
        _interestRepository = interestRepository;
        _fileService = fileService;
    }

    public async Task<bool> Handle(DeleteInterestCommand request, CancellationToken cancellationToken)
    {
        Interest interest = await _interestRepository.GetInterestByIdAsync(request.id);
        if (interest is null)
        {
            throw new InterestNotFoundException(request.id);
        }

        bool isDeleted = _interestRepository.DeleteInterest(request.id);
        if (isDeleted && interest.Image is not null)
        {
            _fileService.DeleteFileAsync(interest.Image);
        }

        return isDeleted;
    }
}
