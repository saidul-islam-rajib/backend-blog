using ErrorOr;
using MediatR;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.InterestAggregates;
using Sober.Domain.Aggregates.UserAggregate.ValueObjects;
using Sober.Domain.Aggregates.InterestAggregates.Entities;
using Sober.Domain.Aggregates.InterestAggregates.ValueObjects;
using Sober.Domain.Aggregates.EducationAggregate.Entities;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Application.Pages.UserInterests.Commands;
public class UpdateInterestCommandHandler
    : IRequestHandler<UpdateInterestCommand, ErrorOr<Interest>>
{
    private readonly IInterestRepository _interestRepository;
    private readonly IFileService _fileService;

    public UpdateInterestCommandHandler(IInterestRepository interestRepository, IFileService fileService)
    {
        _interestRepository = interestRepository;
        _fileService = fileService;
    }

    public async Task<ErrorOr<Interest>> Handle(UpdateInterestCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        Interest interest = await _interestRepository.GetInterestByIdAsync(request.InterestId);
        if (interest is null)
        {
            throw new InterestNotFoundException(request.InterestId);
        }
        if (request.Image is not null && interest.Image is not null)
        {
            _fileService.DeleteFileAsync(interest.Image);
        }

        interest.Title = request.Title ?? interest.Title;
        interest.Image = request.Image ?? interest.Image;


        if (request.Keys is not null)
        {
            foreach (var requestSection in request.Keys)
            {
                var existingSection = interest.Keys.FirstOrDefault(x => x.Key == requestSection.Key);

                if (existingSection is null)
                {
                    var newSection = InterestKey.Create(requestSection.Key);
                    interest.Keys.Add(newSection);
                }
            }
        }

        bool isUpdated = await _interestRepository.UpdateInterestAsync(interest);
        if (!isUpdated)
        {
            throw new FailedException("Failed to update interest!");
        }

        return interest;
    }
}
