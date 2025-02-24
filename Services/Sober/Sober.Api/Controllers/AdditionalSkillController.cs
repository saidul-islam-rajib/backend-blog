using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
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
        private readonly IFileService _fileService;

        public AdditionalSkillController(IMapper mapper, ISender mediator, IFileService fileService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _fileService = fileService;
        }

        [HttpPost]
        [Route("user/{userId}/create-additional-skill")]
        public async Task<IActionResult> CreatePublication([FromForm] AdditionalSkillRequest request, Guid userId)
        {
            string logoPath = await _fileService.SaveFileAsync(request.Image);
            var command = _mapper.Map<CreateAdditionalSkillCommand>((request, userId, logoPath));
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
