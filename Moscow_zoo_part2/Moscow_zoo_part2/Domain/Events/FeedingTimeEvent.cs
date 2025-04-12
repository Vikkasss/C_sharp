namespace Moscow_zoo_part2.Domain.Events;

public class FeedingTimeEvent
{
    public Guid FeedingScheduleId { get; set; }
    public Guid AnimalId { get; set; }
    public DateTime FeedingTime { get; set; }

    public FeedingTimeEvent(Guid feedingScheduleId, Guid animalId, DateTime feedingTime)
    {
        FeedingScheduleId = feedingScheduleId;
        AnimalId = animalId;
        FeedingTime = feedingTime;
    }
}