using Moscow_zoo_part2.Domain.Entities;

namespace Moscow_zoo_part2.Domain.Interfaces;

public interface IEnclosureRepository
{
    Task<Enclosure> GetByIdAsync(Guid id);
    Task<IEnumerable<Enclosure>> GetAllAsync();
    Task AddAsync(Enclosure animal);
    Task UpdateAsync(Enclosure animal);
    Task DeleteAsync(Guid id);
}