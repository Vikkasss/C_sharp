using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;
using Moscow_zoo_part2.Presentation.DTOs;
using MediatR;
namespace Moscow_zoo_part2.Application.Queries;

public class GetAnimalQuery : IRequest<IEnumerable<AnimalDTO>>
{
    public Guid? AnimalId { get; set; }

    public GetAnimalQuery(Guid? animalId)
    {
        AnimalId = animalId;
    }
}
