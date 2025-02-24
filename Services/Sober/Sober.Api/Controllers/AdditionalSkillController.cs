using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.AdditionalSkills.Commands;
using Sober.Application.Pages.AdditionalSkills.Queries;
using Sober.Contracts.Request;
using Sober.Contracts.Response;

namespace Sober.Api.Controllers
{
    [Route("[controller]")]
    public class AdditionalSkillController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;

        public AdditionalSkillController(IMapper mapper, ISender mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("user/{userId}/create-additional-skill")]
        public async Task<IActionResult> CreatePublication(AdditionalSkillRequest request, Guid userId)
        {
            var command = _mapper.Map<CreateAdditionalSkillCommand>((request, userId));
            var result = await _mediator.Send(command);

            var response = result.Match(
                skill =>
                {
                    var mappedResponse = _mapper.Map<AdditionalSkillResponse>(skill);
                    return Ok(mappedResponse);
                },
                errors => Problem(errors)
            );

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-additional-skill")]
        public async Task<IActionResult> GetPublications()
        {
            var query = new GetAdditionalSkillQuery();
            var result = await _mediator.Send(query);
            var response = _mapper.Map<IEnumerable<AdditionalSkillResponse>>(result);

            return Ok(response);
        }


    }
}
