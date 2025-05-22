using BuildingBlocks.Exceptions;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Sober.Application.Interfaces;
using Sober.Domain.Aggregates.TagAggregates;

namespace Sober.Application.Pages.Tags.Commands;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, bool>
{
    private readonly ITagRepository _tagRepository;
    private readonly IDistributedCache _cache;


    public DeleteTagCommandHandler(ITagRepository tagRepository, IDistributedCache cache)
    {
        _tagRepository = tagRepository;
        _cache = cache;
    }

    public async Task<bool> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        Tag tag = await _tagRepository.GetTagByIdAsync(request.tagId);
        if (tag is null)
        {
            throw new NotFoundException($"Tag with ID {request.tagId} not found.");
        }
        bool isDeleted = _tagRepository.DeleteTag(request.tagId);
        if (isDeleted)
        {
            // Remove individual tag from cache
            string tagCacheKey = $"tag:{request.tagId}";
            await _cache.RemoveAsync(tagCacheKey, cancellationToken);

            // Invalidate the tag list cache
            await _cache.RemoveAsync("tags:all", cancellationToken);
        }

        return isDeleted;
    }

}
