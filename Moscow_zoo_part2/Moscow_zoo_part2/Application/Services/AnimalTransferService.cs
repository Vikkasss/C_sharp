using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Events;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Services;

public class AnimalTransferService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;
    private readonly IEventRepository _eventRepository;

    public AnimalTransferService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository,
        IEventRepository eventRepository)
    {
        _animalRepository = animalRepository;
        _enclosureRepository = enclosureRepository;
        _eventRepository = eventRepository;
    }

    public async Task TransferAnimalAsync(Guid animalId, Guid newEnclosureId)
    {
        var animal = await _animalRepository.GetByIdAsync(animalId);
        if (animal == null)
        {
            throw new InvalidOperationException("Animal not found");
        }

        var oldEnclosure = await _enclosureRepository.GetByIdAsync(animal.EnclosureId);
        if (oldEnclosure == null)
        {
            throw new InvalidOperationException("Old Enclosure not found");
        }
        
        var newEnclosure = await _enclosureRepository.GetByIdAsync(newEnclosureId);
        if (newEnclosure == null)
        {
            throw new InvalidOperationException("New Enclosure not found");
        }
        
        oldEnclosure.RemoveAnimal(animal.Id);
        newEnclosure.AddAnimal(animal.Id);
        animal.MoveToEnclosure(newEnclosure.Id);
        
        await _animalRepository.UpdateAsync(animal);
        await _enclosureRepository.UpdateAsync(oldEnclosure);
        await _enclosureRepository.UpdateAsync(newEnclosure);
        
        _eventRepository.Publish(new AnimalMovedEvent(animalId, oldEnclosure.Id, newEnclosure.Id));
    }
}