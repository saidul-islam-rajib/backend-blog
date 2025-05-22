using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Tags.Commands;
using Sober.Application.Pages.Tags.Queries;
using Sober.Application.Pages.Topics.Queries.Query;
using Sober.Application.Pages.UserInterests.Queries;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Contracts.Response.Skills;

namespace Sober.Api.Controllers;

[Route("[controller]")]
public class TagController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public TagController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetInterests()
    {
        var query = new GetAllTagQuery();
        var result = await _mediator.Send(query);
        var response = _mapper.Map<IEnumerable<TagResponse>>(result);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{tagId}")]
    public async Task<IActionResult> GetTagById(Guid tagId)
    {
        var query = new GetTagByIdQuery(tagId);
        var tag = await _mediator.Send(query);
        if (tag is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<TagResponse>(tag);
        return Ok(response);
    }


    [HttpPost]
    [Route("user/{userId}/create")]
    public async Task<IActionResult> CreateTagAsync(TagRequest request, Guid userId)
    {
        var command = _mapper.Map<CreateTagCommand>((request, userId));
        var result = await _mediator.Send(command);

        var response = result.Match(tag => Ok(_mapper.Map<TagResponse>(tag)),
            errors => Problem(errors));
        return Ok(response);
    }

    [HttpPut]
    [Route("user/{userId}/update/{tagId}")]
    public async Task<IActionResult> UpdateTagAsync(TagRequest request, Guid userId, Guid tagId)
    {
        var command = _mapper.Map<UpdateTagCommand>((request, userId, tagId));
        var result = await _mediator.Send(command);

        var response = result.Match(
            success => Ok(new
            {
                Success = true,
                Message = $"Tag with ID `{tagId}` has been successfully updated by User `{userId}`.",
                Data = _mapper.Map<TagResponse>(success)
            }),
            errors => Problem(errors)
        );
        return Ok(response);
    }

    [HttpDelete]
    [Route("{tagId}/delete")]
    public async Task<IActionResult> DeleteTagAsync(Guid tagId)
    {
        var command = new DeleteTagCommand(tagId);
        var result = await _mediator.Send(command);

        if (result)
        {
            return Ok(new
            {
                Success = true,
                Message = $"Tag with ID `{tagId}` has been successfully deleted."
            });
        }

        return NotFound($"Tag with ID {tagId} not found.");
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-tags-with-topic")]
    public async Task<IActionResult> GetTagsWithTopicAsync()
    {
        var query = new GetTagsWithTopicsQuery();
        var tags = await _mediator.Send(query);
        if (tags is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<IEnumerable<TagWithTopicResponse>>(tags);
        return Ok(response);
    }
}
