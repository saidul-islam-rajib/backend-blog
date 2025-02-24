using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.Pages.Experiences.Commands;
using Sober.Application.Pages.Experiences.Queries.Query;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.ExperienceAggregate;

namespace Sober.Api.Controllers;

[Route("[controller]")]
public class ExperienceController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IFileService _fileService;

    public ExperienceController(ISender mediator, IMapper mapper, IFileService fileService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _fileService = fileService;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("users/{userId}/create")]
    public async Task<IActionResult> CreateExperience([FromForm] ExperienceRequest request, Guid userId)
    {
        string logoPath = await _fileService.SaveFileAsync(request.CompanyLogo);
        var command = _mapper.Map<CreateExperienceCommand>((request, userId, logoPath));
        var result = await _mediator.Send(command);

        var response = result.Match(
            experience => Ok(_mapper.Map<ExperienceResponse>(experience)),
            errors => Problem(errors));

        return response;
    }

    [HttpPut]
    [Route("user/{userId}/update-experience/{experienceId}")]
    public async Task<IActionResult> UpdateExperienceAsync(ExperienceRequest request, Guid userId, Guid experienceId)
    {
        var command = _mapper.Map<UpdateExperienceCommand>((request, userId, experienceId));
        var result = await _mediator.Send(command);

        var response = result.Match(
            success => Ok(new
            {
                Success = true,
                Message = $"Experience with ID `{experienceId}` has been successfully updated by User `{userId}`.",
                Data = _mapper.Map<ExperienceResponse>(success)
            }),
            errors => Problem(errors)
        );

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-experiences")]
    public async Task<IActionResult> GetExperiences()
    {
        var query = new GetExperienceQuery();
        IEnumerable<Experience> experiences = await _mediator.Send(query);
        var response = _mapper.Map<IEnumerable<ExperienceResponse>>(experiences);

        return Ok(response);
    }
}
