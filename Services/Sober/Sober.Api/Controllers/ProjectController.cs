using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.Pages.Projects.Commands;
using Sober.Application.Pages.Projects.Queries;
using Sober.Contracts.Request;
using Sober.Contracts.Response;

namespace Sober.Api.Controllers;

[Route("[controller]")]
public class ProjectController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IFileService _fileService;

    public ProjectController(IMapper mapper, ISender mediator, IFileService fileService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _fileService = fileService;
    }

    [HttpPost]
    [Route("user/{userId}/create-project")]
    public async Task<IActionResult> CreateProject([FromForm] ProjectRequest request, Guid userId)
    {
        string logoPath = await _fileService.SaveFileAsync(request.ProjectImage);
        var command = _mapper.Map<CreateProjectCommand>((request, userId, logoPath));
        var result = await _mediator.Send(command);

        var response = result.Match(
            experience => Ok(_mapper.Map<ProjectResponse>(experience)),
            errors => Problem(errors));

        return response;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-projects")]
    public async Task<IActionResult> GetAllSkills()
    {
        var query = new GetAllProjectQuery();
        var projects = await _mediator.Send(query);
        if (projects is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<IEnumerable<ProjectResponse>>(projects);
        return Ok(response);
    }
}
