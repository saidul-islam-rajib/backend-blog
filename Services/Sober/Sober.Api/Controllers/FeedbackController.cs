using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sober.Api.Controllers.Base;
using Sober.Application.Pages.Feedbacks.Commands;
using Sober.Application.Pages.Feedbacks.Queries;
using Sober.Contracts.Request;
using Sober.Contracts.Response;
using Sober.Domain.Aggregates.FeedbackAggregate;

namespace Sober.Api.Controllers;

[Route("[controller]")]
public class FeedbackController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public FeedbackController(IMapper mapper, ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateFeedback(FeedbackRequest request)
    {
        var command = _mapper.Map<CreateFeedbackCommand>(request);
        var result = await _sender.Send(command);

        var response = result.Match(
            feedback => Ok(_mapper.Map<FeedbackResponse>(feedback)),
            errors => Problem(errors));

        return response;
    }

    [HttpPut]
    [Route("user/{userId}/update/{feedbackId}")]
    public async Task<IActionResult> UpdateFeedbackAsync(UpdateFeedbackRequest request, Guid userId, Guid feedbackId)
    {
        var command = _mapper.Map<UpdateFeedbackCommand>((request, userId, feedbackId));
        var result = await _sender.Send(command);

        var response = result.Match(
            success => Ok(new
            {
                Success = true,
                Message = $"Feedback with ID `{feedbackId}` has been successfully updated by User `{userId}`.",
                Data = _mapper.Map<UpdateFeedbackResponse>(success)
            }),
            errors => Problem(errors)
        );
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("getall")]
    public async Task<IActionResult> GetAllFeedback()
    {
        var query = new GetFeedbackQuery();
        IEnumerable<Feedback> feedbacks = await _sender.Send(query);
        var response = _mapper.Map<IEnumerable<FeedbackResponse>>(feedbacks);

        return Ok(response);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("get/{feedbackId}")]
    public async Task<IActionResult> GetFeedbackById(Guid feedbackId)
    {
        var query = new GetFeedbackByIdQuery(feedbackId);
        var feedback = await _sender.Send(query);
        if (feedback is null)
        {
            return NotFound();
        }

        var response = _mapper.Map<FeedbackResponse>(feedback);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{feedbackId}/delete")]
    public async Task<IActionResult> DeleteFeedbackAsync(Guid feedbackId)
    {
        var command = new DeleteFeedbackCommand(feedbackId);
        var result = await _sender.Send(command);

        if (result)
        {
            return Ok(new
            {
                Success = true,
                Message = $"Feedback with ID `{feedbackId}` has been successfully deleted."
            });
        }

        return NotFound($"Feedback with ID {feedbackId} not found.");
    }
}
