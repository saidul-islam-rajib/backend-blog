using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.Pages.Publications.Commands;
using Sober.Application.Pages.Publications.Queries.Query;
using Sober.Contracts.Request;
using Sober.Contracts.Response;

namespace Sober.Api.Controllers.Publication;

[Route("[controller]")]
public class PublicationController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;
    private readonly IFileService _fileService;

    public PublicationController(IMapper mapper, ISender mediator, IFileService fileService)
    {
        _mapper = mapper;
        _mediator = mediator;
        _fileService = fileService;
    }

    [HttpPost]
    [Route("users/{userId}/create-publication")]
    public async Task<IActionResult> CreatePublication([FromForm] PublicationRequest request, Guid userId)
    {
        string logoPath = await _fileService.SaveFileAsync(request.PublicationImage);
        var command = _mapper.Map<CreatePublicationCommand>((request, userId, logoPath));
        var result = await _mediator.Send(command);

        var response = result.Match(
                publication => Ok(_mapper.Map<PublicationResponse>(publication)),
                errors => Problem(errors));

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get-publications")]
    public async Task<IActionResult> GetPublications()
    {
        var query = new GetPublicationQuery();
        var result = await _mediator.Send(query);
        var response = _mapper.Map<IEnumerable<PublicationResponse>>(result);

        return Ok(response);
    }


}
