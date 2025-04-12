using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Interfaces;

namespace Moscow_zoo_part2.Infrastructure.Repositories;

public class InMemoryFeedingScheduleRepository : IFeedingScheduleRepository
{
    private readonly Dictionary<Guid, FeedingSchedule> _feedingSchedules = new Dictionary<Guid, FeedingSchedule>();

    public async Task<FeedingSchedule> GetByIdAsync(Guid id)
    {
        return _feedingSchedules.ContainsKey(id) ? _feedingSchedules[id] : null;
    }

    public async Task<IEnumerable<FeedingSchedule>> GetAllAsync()
    {
        return _feedingSchedules.Values;
    }

    public async Task AddAsync(FeedingSchedule feedingSchedule)
    {
        _feedingSchedules.Add(feedingSchedule.Id, feedingSchedule);
    }

    public async Task UpdateAsync(FeedingSchedule feedingSchedule)
    {
        if (_feedingSchedules.ContainsKey(feedingSchedule.Id))
        {
            _feedingSchedules[feedingSchedule.Id] = feedingSchedule;
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        if (_feedingSchedules.ContainsKey(id))
        {
            _feedingSchedules.Remove(id);
        }
    }
}