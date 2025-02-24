using BuildingBlocks.Exceptions;
using MediatR;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Commands;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, bool>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        Tag tag = await _tagRepository.GetTagByIdAsync(request.tagId);
        if (tag is null)
        {
            throw new NotFoundException($"Tag with ID {request.tagId} not found.");
        }
        bool isDeleted = _tagRepository.DeleteTag(request.tagId);

        return isDeleted;
    }

}
