using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moscow_zoo_part2.Domain.Interfaces;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Presentation.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController : ControllerBase
{
    private readonly IMediator _mediator;

    public AnimalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAnimals()
    {
        var query = new GetAllAnimalQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimal(Guid id)
    {
        var query = new GetAnimalQuery(id);
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAnimal([FromBody] AnimalDTO dto)
    {
        var command = new AddAnimalCommand(
            dto.Species,
            dto.Name,
            dto.DateOfBirth,
            dto.Gender,
            dto.FavoriteFood
            );
        await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAnimal), new { id = command.Name }, dto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAnimal(Guid id)
    {
        var command = new RemoveAnimalCommand(id);
        await _mediator.Send(command);
        return NoContent();
    }
}