using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sober.Application.CustomeExceptions.NotFoundExceptions;
using Sober.Application.CustomExceptions.NotFoundExceptions;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Commands;

public class UpdateTagCommandHandler
    : IRequestHandler<UpdateTagCommand, ErrorOr<Tag>>
{
    private readonly ITagRepository _tagRepository;
    private readonly ProblemDetailsFactory _problemDetailsFactory;

    public UpdateTagCommandHandler(ITagRepository tagRepository, ProblemDetailsFactory problemDetailsFactory)
    {
        _tagRepository = tagRepository;
        _problemDetailsFactory = problemDetailsFactory;
    }

    public async Task<ErrorOr<Tag>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        var tag = await _tagRepository.GetTagByIdAsync(request.TagId);
        if(tag is null)
        {
            throw new TagNotFoundException(request.TagId);
        }

        tag.TagName = request.TagName;

        var isUpdated = await _tagRepository.UpdateTagAsync(tag);
        if (!isUpdated)
        {
            throw new TagFailedException("Failed to update!");
        }

        return tag;
    }
}
