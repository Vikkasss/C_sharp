using MediatR;

namespace Moscow_zoo_part2.Application.Commands;

public class RemoveAnimalCommand : IRequest<Unit>
{
    public Guid AnimalId { get; set; }

    public RemoveAnimalCommand(Guid animalId)
    {
        AnimalId = animalId;
    }
}