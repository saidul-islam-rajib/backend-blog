using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Common.Interfaces.Services;
using Sober.Application.Pages.Educations.Commands;
using Sober.Application.Pages.Educations.Queries.Query;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.EducationAggregate;

namespace Sober.Api.Controllers
{
    [Route("[controller]")]
    public class EducationController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly ISender _mediator;
        private readonly IFileService _fileService;

        public EducationController(ISender mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("users/{userId}/create")]
        public async Task<IActionResult> CreateEducation([FromForm] EducationRequest request, Guid userId)
        {

            string logoPath = await _fileService.SaveFileAsync(request.InstituteLogo);

            var command = _mapper.Map<CreateEducationCommand>((request, userId, logoPath));
            var result = await _mediator.Send(command);

            var response = result.Match(
                education => Ok(_mapper.Map<EducationResponse>(education)),
                errors => Problem(errors));

            return response;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("get-educations")]
        public async Task<IActionResult> GetEducations()
        {
            var query = new GetEducationQuery();
            IEnumerable<Education> educations = await _mediator.Send(query);
            var response = _mapper.Map<IEnumerable<EducationResponse>>(educations);

            return Ok(response);
        }
    }
}
