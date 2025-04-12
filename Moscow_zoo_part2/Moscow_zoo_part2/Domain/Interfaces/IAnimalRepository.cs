using Moscow_zoo_part2.Domain.Entities;

namespace Moscow_zoo_part2.Domain.Interfaces;

public interface IAnimalRepository
{
    Task<Animal> GetByIdAsync(Guid id);
    Task<IEnumerable<Animal>> GetAllAsync();
    Task AddAsync(Animal animal);
    Task UpdateAsync(Animal animal);
    Task DeleteAsync(Guid id);
    
}