using Moscow_zoo_part2.Application.Commands;
using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;
using MediatR;
using Moscow_zoo_part2.Application.Queries;
using Moscow_zoo_part2.Presentation.DTOs;

namespace Moscow_zoo_part2.Application.Handlers;

public class GetAnimalQueryHandler :  IRequestHandler<GetAnimalQuery, IEnumerable<AnimalDTO>>
{
    private readonly IAnimalRepository _animalRepository;

    public GetAnimalQueryHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<IEnumerable<AnimalDTO>> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Animal> animals;
        if (request.AnimalId.HasValue)
        {
            var animal = await _animalRepository.GetByIdAsync(request.AnimalId.Value);
            animals = animal != null ? new List<Animal> {animal} : Enumerable.Empty<Animal>();
        }
        else
        {
            animals = await _animalRepository.GetAllAsync();
        }
        return animals.Select(a => new AnimalDTO
        {
            Id = a.Id,
            Species = a.Species,
            Name = a.Name,
            DateOfBirth = a.BirthDate,
            Gender = a.Gender, // Предполагается, что Gender — перечисление
            FavoriteFood = a.FavoriteFood,
            IsHealthy = a.isHealthy,
            CurrentEnclosureId = a.EnclosureId // Исправлено именование
        });
    }
}