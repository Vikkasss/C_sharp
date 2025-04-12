using MediatR;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Domain.Interfaces;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Handlers;

public class GetAllAnimalQueryHandler : IRequestHandler<GetAllAnimalQuery, IEnumerable<AnimalDTO>>
{
    private readonly IAnimalRepository _animalRepository;

    public GetAllAnimalQueryHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    
    public async Task<IEnumerable<AnimalDTO>> Handle(GetAllAnimalQuery request, CancellationToken cancellationToken)
    {
        var aninals = await _animalRepository.GetAllAsync();
        return aninals.Select(e => new AnimalDTO
        {
            Id = e.Id,
            Name = e.Name,
            Species = e.Species,
            DateOfBirth = e.BirthDate,
            Gender = e.Gender,
            FavoriteFood = e.FavoriteFood,
            IsHealthy = e.isHealthy,
            CurrentEnclosureId = e.EnclosureId,
        });
    }
}