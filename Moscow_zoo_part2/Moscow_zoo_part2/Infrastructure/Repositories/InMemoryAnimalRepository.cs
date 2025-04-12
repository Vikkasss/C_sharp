using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Infrastructure.Repositories;

public class InMemoryAnimalRepository : IAnimalRepository
{
    private readonly Dictionary<Guid, Animal> _animals = new Dictionary<Guid, Animal>();

    public async Task<Animal> GetByIdAsync(Guid id)
    {
        return _animals.ContainsKey(id) ? _animals[id] : null;
    }

    public async Task<IEnumerable<Animal>> GetAllAsync()
    {
        return _animals.Values;
    }

    public async Task AddAsync(Animal animal)
    {
        // _animals.Add(animal.Id, animal);
        _animals[animal.Id] = animal;
    }

    public async Task UpdateAsync(Animal animal)
    {
        if (_animals.ContainsKey(animal.Id))
        {
            _animals[animal.Id] = animal;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        if (_animals.ContainsKey(id))
        {
            _animals.Remove(id);
        }
    }
}