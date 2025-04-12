using Moscow_zoo_part2.Domain.Entities;

namespace Moscow_zoo_part2.Domain.Interfaces;

public interface IFeedingScheduleRepository
{
    Task<FeedingSchedule> GetByIdAsync(Guid id);
    Task<IEnumerable<FeedingSchedule>> GetAllAsync();
    Task AddAsync(FeedingSchedule animal);
    Task UpdateAsync(FeedingSchedule animal);
    Task DeleteAsync(Guid id);
}