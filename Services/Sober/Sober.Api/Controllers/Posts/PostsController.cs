using BuildingBlocks.Pagination;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.Posts.Commands;
using Sober.Application.Posts.Queries.Query;
using Sober.Contracts.Request.Posts;
using Sober.Contracts.Response.Posts;

namespace Sober.Api.Controllers.Posts;

[Route("[controller]")]
public class PostsController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IFileService _fileService;

    public PostsController(IMapper mapper, ISender mediator, IFileService fileService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _fileService = fileService;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-paginated-posts")]
    public async Task<IActionResult> GetPaginatedPost([FromQuery] int pageIndex, [FromQuery] int pageSize=10)
    {
        var query = new GetPaginatedPostsQuery(pageIndex, pageSize);
        var paginatedPosts = await _mediator.Send(query);

        var response = _mapper.Map<PaginationResult<PostResponse>>(paginatedPosts);

        return Ok(response);
    }

    [HttpPost]
    [Route("users/{userId}/create-new-post")]
    public async Task<IActionResult> CreatePostRequestAsync([FromForm] PostRequest request, Guid userId)
    {
        string postImagePath = await _fileService.SaveFileAsync(request.PostImage);

        var updatedSections = new List<PostSectionCommand>();

        foreach (var section in request.Sections)
        {
            var updatedItems = new List<PostSectionItemCommand>();

            foreach (var item in section.Items)
            {
                string itemImagePath = item.ItemImage != null ? await _fileService.SaveFileAsync(item.ItemImage) : "";
                var updatedItem = new PostSectionItemCommand(
                    item.ItemTitle,
                    itemImagePath,
                    item.ItemDescription
                );

                updatedItems.Add(updatedItem);
            }

            var updatedSection = new PostSectionCommand(
                section.SectionTitle,
                section.SectionDescription,
                updatedItems
            );

            updatedSections.Add(updatedSection);
        }

        var command = new CreatePostCommand(
            userId,
            request.PostTitle,
            postImagePath,
            request.PostAbstract,
            request.Conclusion,
            request.ReadingMinute,
            _mapper.Map<List<PostSectionCommand>>(updatedSections),
            _mapper.Map<List<TopicCommand>>(request.Topics)
        );

        var result = await _mediator.Send(command);

        var response = result.Match(
            post => Ok(_mapper.Map<PostResponse>(post)),
            errors => Problem(errors));

        return response;
    }



    [AllowAnonymous]
    [HttpGet]
    [Route("get-all-posts")]
    public async Task<IActionResult> GetAllPosts()
    {
        var query = new GetAllPostsQuery();
        var posts = await _mediator.Send(query);
        var response = _mapper.Map<IEnumerable<PostResponse>>(posts);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{postId}")]
    public async Task<IActionResult> GetPostByIdQuery(Guid postId)
    {
        var query = new GetPostByIdQuery(postId);
        var post = await _mediator.Send(query);
        if(post is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<PostResponse>(post);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-post-by-title")]
    public async Task<IActionResult> GetPostByTitle(string title)
    {
        var query = new GetPostByTitleQuery(title);
        var posts = await _mediator.Send(query);
        if(posts is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<IEnumerable<PostResponse>>(posts);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-post-by-topic-title")]
    public async Task<IActionResult> GetPostByTopicTitle(string topicTitle)
    {
        var query = new GetPostByTopicTitleQuery(topicTitle);
        var posts = await _mediator.Send(query);
        if(posts is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<IEnumerable<PostResponse>>(posts);
        return Ok(response);
    }
}
