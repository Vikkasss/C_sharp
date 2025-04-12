using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Presentation.Controllers;


[ApiController]
[Route("api/enclosures")]
public class EnclosureController : ControllerBase
{
    private readonly IMediator _mediator;

    public EnclosureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEnclosures(string? enclosureType)
    {
        var query = new GetAllEnclosureQuery(enclosureType);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnclosure(Guid id)
    {
        var enclosures = await _mediator.Send(new GetEnclosureQuery(id));
        return enclosures != null ? Ok(enclosures) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddEnclosure([FromBody] EnclosuredDTO dto)
    {
        var command = new AddEnclosureCommand(
            dto.Type,
            dto.Size,
            dto.CurrentCapacity,
            dto.MaxCapacity);
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetEnclosure), new { id = command.Type }, dto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnclosure(Guid id)
    {
        var command = new RemoveEnclosureCommand(id);
        var result = await _mediator.Send(command);
        return NoContent();
    }
}
    
