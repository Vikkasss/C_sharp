using MediatR;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Queries;

public class GetAllAnimalQuery : IRequest<IEnumerable<AnimalDTO>>
{
    
}