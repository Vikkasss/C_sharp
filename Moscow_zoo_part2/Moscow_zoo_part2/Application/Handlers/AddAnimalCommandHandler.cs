using MediatR;
using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Handlers;

public class AddAnimalCommandHandler : IRequestHandler<AddAnimalCommand, Unit>
{
    private readonly IAnimalRepository _animalRepository;

    public AddAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<Unit> Handle(AddAnimalCommand request, CancellationToken cancellationToken)
    {
        var animal = new Animal(request.Species, 
            request.Name, 
            request.DateOfBirth, 
            request.Gender,
            request.FavoriteFood);
        
        await _animalRepository.AddAsync(animal);
        
        return Unit.Value;
    }
}