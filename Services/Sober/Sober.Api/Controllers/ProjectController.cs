using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
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

    public ProjectController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("user/{userId}/create-project")]
    public async Task<IActionResult> CreateProject(ProjectRequest request, Guid userId)
    {
        var command = _mapper.Map<CreateProjectCommand>((request, userId));
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
