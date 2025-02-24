using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.Pages.UserInterests.Commands;
using Sober.Application.Pages.UserInterests.Queries;
using Sober.Contracts.Request;
using Sober.Contracts.Response;

namespace Sober.Api.Controllers;

[Route("[controller]")]
public class InterestController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IFileService _fileService;

    public InterestController(IMapper mapper, ISender mediator, IFileService fileService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _fileService = fileService;
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-interests")]
    public async Task<IActionResult> GetInterests()
    {
        var query = new GetInterestQuery();
        var result = await _mediator.Send(query);
        var response = _mapper.Map<IEnumerable<InterestResponse>>(result);

        return Ok(response);
    }

    [HttpPost]
    [Route("users/{userId}/create-interest")]
    public async Task<IActionResult> CreateInterest([FromForm] InterestRequest request, Guid userId)
    {
        string logoPath = await _fileService.SaveFileAsync(request.Image);
        var command = _mapper.Map<CreateInterestCommand>((request, userId, logoPath));
        var result = await _mediator.Send(command);

        var response = result.Match(
                interest => Ok(_mapper.Map<InterestResponse>(interest)),
                errors => Problem(errors));

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("{interestId}")]
    public async Task<IActionResult> GetInterestById(Guid interestId)
    {
        var query = new GetInterestByIdQuery(interestId);
        var interest = await _mediator.Send(query);
        if (interest is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<InterestResponse>(interest);
        return Ok(response);
    }
}
