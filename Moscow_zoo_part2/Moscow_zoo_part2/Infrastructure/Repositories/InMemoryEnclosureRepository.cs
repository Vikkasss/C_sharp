using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Infrastructure.Repositories;

public class InMemoryEnclosureRepository : IEnclosureRepository
{
    private readonly Dictionary<Guid, Enclosure> _enclosures = new Dictionary<Guid, Enclosure>();

    public async Task<Enclosure> GetByIdAsync(Guid id)
    {
        return _enclosures.ContainsKey(id) ? _enclosures[id] : null;
    }

    public async Task<IEnumerable<Enclosure>> GetAllAsync()
    {
        return _enclosures.Values;
    }

    public async Task AddAsync(Enclosure enclosure)
    {
        // _enclosures.Add(enclosure.Id, enclosure); check
        _enclosures.Add(enclosure.Id, enclosure);
    }

    public async Task UpdateAsync(Enclosure enclosure)
    {
        if (_enclosures.ContainsKey(enclosure.Id))
        {
            _enclosures[enclosure.Id] = enclosure;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        if (_enclosures.ContainsKey(id))
        {
            _enclosures.Remove(id);
        }
    }
}