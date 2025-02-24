using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
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

    public PublicationController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("users/{userId}/create-publication")]
    public async Task<IActionResult> CreatePublication(PublicationRequest request, Guid userId)
    {
        var command = _mapper.Map<CreatePublicationCommand>((request, userId));
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
