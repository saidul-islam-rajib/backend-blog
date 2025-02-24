using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Users.Commands;
using Sober.Application.Pages.Users.Queries;
using Sober.Contracts.Request.UserInformation;
using Sober.Contracts.Response;
using Sober.Contracts.Response.UserInformation;

namespace Sober.Api.Controllers.UserInformation;

[Route("[controller]")]
public class UserController : ApiController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    public UserController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    [Route("user/{userId}/create-user-information")]
    public async Task<IActionResult> UserInformation(UserInformationRequest request, Guid userId)
    {
        var command = _mapper.Map<CreateUserInformationCommand>((request, userId));
        var result = await _mediator.Send(command);

        var response = result.Match(
            user => Ok(_mapper.Map<UserInformationResponse>(user)),
            errors => Problem(errors));

        return response;
    }

    [HttpGet]
    [Route("{userId}/get-user-information")]
    public async Task<IActionResult> GetUserInformationByUserId(Guid userId)
    {
        var query = new GetUserInformationByIdQuery(userId);
        var user = await _mediator.Send(query);

        if (user is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<UserInformationResponse>(user);
        return Ok(response);
    }



    [HttpGet]
    [Route("get-default-user")]
    public async Task<IActionResult> GetDefaultUser()
    {
        var query = new GetDefaultUserQuery();
        var user = await _mediator.Send(query);
        if(user is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<UserInformationResponse>(user);
        return Ok(response);
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        var user = await _mediator.Send(query);

        if(user is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<UserResponse>(user);
        return Ok(response);
    }
}
