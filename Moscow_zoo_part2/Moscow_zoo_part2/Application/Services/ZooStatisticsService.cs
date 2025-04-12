using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Application.Services;

public class ZooStatisticsService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IEnclosureRepository _enclosureRepository;

    public ZooStatisticsService(IAnimalRepository animalRepository, IEnclosureRepository enclosureRepository)
    {
        _animalRepository = animalRepository;
        _enclosureRepository = enclosureRepository;
    }

    public async Task<int> GetTotalAnimalCountAsync()
    {
        var animals = await _animalRepository.GetAllAsync();
        return animals.Count();
    }

    public async Task<int> GetFreeEncosuresCountAsync()
    {
        var enclosures = await _enclosureRepository.GetAllAsync();
        return enclosures.Count(e => e.CurrentCapacity < e.MaxCapacity);
    }

    public async Task<int> GetHealthyAnimalCountAsync()
    {
        var animals = await _animalRepository.GetAllAsync();
        return animals.Count(a => a.isHealthy);
    }
}