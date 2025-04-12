using Moscow_zoo_part2.Domain.ValueObjects;

namespace Moscow_zoo_part2.Presentation.DTOs;

public class FeedingScheduleDTO
{
    public Guid Id { get; set; }
    public Guid AnimalId { get; set; }
    public DateTime FeedingTime { get; set; }
    public FoodType FoodType { get; set; }
    public bool IsCompleted { get; set; }
}
