using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Application.Queries;

namespace Moscow_zoo_part2.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/feeding-schedules")]
public class FeedingScheduleController : ControllerBase
{
    private readonly IMediator _mediator;

    public FeedingScheduleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddFeedingSchedule([FromBody] AddFeedingScheduleCommand command)
    {
        await _mediator.Send(command);
        return CreatedAtAction(nameof(GetFeedingSchedules), null);
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> MarkFeedingScheduleAsCompleted(Guid id)
    {
        var command = new MarkFeedingScheduleAsCompletedCommand(id);
        await _mediator.Send(command);
        return NoContent(); 
    }
}
    
