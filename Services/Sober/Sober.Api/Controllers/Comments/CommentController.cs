using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Comments.Commands;
using Sober.Application.Pages.Comments.Queries.Query;
using Sober.Contracts.Request.Comments;
using Sober.Contracts.Response.Comments;
using Sober.Domain.Aggregates.CommentAggregate;

namespace Sober.Api.Controllers.Comments;

[Route("[controller]")]
public class CommentController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public CommentController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("posts/{postId}/create-comment")]
    public async Task<IActionResult> CreateComment(CommentRequest request, Guid postId)
    {
        var command = _mapper.Map<CreateCommentCommand>((request, postId));
        var result = await _mediator.Send(command);

        var response = result.Match(
            comment => Ok(_mapper.Map<CommentResponse>(comment)),
            errors => Problem(errors));

        return response;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-all-comments")]
    public async Task<IActionResult> GetAllComments()
    {
        var query = new GetAllCommentsQuery();
        var comments = await _mediator.Send(query);
        if (comments is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<IEnumerable<CommentResponse>>(comments);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{commentId}")]
    public async Task<IActionResult> GetCommentById(Guid commentId)
    {
        var query = new GetCommentByIdQuery(commentId);
        var comment = await _mediator.Send(query);
        if (comment is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<CommentResponse>(comment);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-comments-by-post-title")]
    public async Task<IActionResult> GetCommentByPostTitle(string postTitle)
    {
        var query = new GetCommentByPostTitleQuery(postTitle);
        var comments = await _mediator.Send(query);
        if(comments is null)
        {
            return NotFound(postTitle);
        }
        var response = _mapper.Map<IEnumerable<Comment>>(comments);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-comments-by-post-id")]
    public async Task<IActionResult> GetCommentByPostId(Guid postId)
    {
        var query = new GetCommentByPostIdQuery(postId);
        var comment = await _mediator.Send(query);
        if (comment is null)
        {
            return NotFound(postId);
        }
        var response = _mapper.Map<List<Comment>>(comment);
        return Ok(response);
    }
}
