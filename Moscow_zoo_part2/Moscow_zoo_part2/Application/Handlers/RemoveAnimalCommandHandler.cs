using MediatR;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class RemoveAnimalCommandHandler : IRequestHandler<RemoveAnimalCommand, Unit>
{
    private readonly IAnimalRepository _animalRepository;

    public RemoveAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<Unit> Handle(RemoveAnimalCommand request, CancellationToken cancellationToken)
    {
        await _animalRepository.DeleteAsync(request.AnimalId);
        return Unit.Value;
    }
}