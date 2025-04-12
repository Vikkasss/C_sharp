using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.Events;
using Moscow_zoo_part2.Domain.Interfaces;
using Moscow_zoo_part2.Domain.ValueObjects;

namespace Moscow_zoo_part2.Application.Services;

public class FeedingOrganizationService
{
    private readonly IFeedingScheduleRepository _feedingScheduleRepository;
    private readonly IEventRepository _eventRepository;

    public FeedingOrganizationService(IFeedingScheduleRepository feedingSchedulePerository,
        IEventRepository eventRepository)
    {
        _feedingScheduleRepository = feedingSchedulePerository;
        _eventRepository = eventRepository;
    }

    public async Task AddFeedingScheduleAsync(Guid animalId, DateTime feedingTime, FoodType foodType)
    {
        var feedingSchedule = new FeedingSchedule(animalId, feedingTime, foodType);
        await _feedingScheduleRepository.AddAsync(feedingSchedule);
        
        _eventRepository.Publish(new FeedingTimeEvent(feedingSchedule.Id, animalId ,feedingTime));
    }

    public async Task MarkFeedingScheduleAsCompletedAsync(Guid feedingScheduleId)
    {
        var feedingSchedule = await _feedingScheduleRepository.GetByIdAsync(feedingScheduleId);
        if (feedingSchedule == null)
        {
            throw new InvalidOperationException("Feeding schedule not found");
        }

        feedingSchedule.MarkAsCompleted();
        await _feedingScheduleRepository.UpdateAsync(feedingSchedule);
    }
}