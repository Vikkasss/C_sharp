using MediatR;
using Moscow_zoo_part2.Domain.ValueObjects;

namespace Moscow_zoo_part2.Application.Commands;

public class AddFeedingScheduleCommand :IRequest<Unit>
{
    public Guid AnimalId { get; set; }
    public DateTime FeedingDate { get; set; }
    public FoodType FoodType { get; set; }

    public AddFeedingScheduleCommand(Guid animalId, DateTime feedingDate, FoodType foodType)
    {
        AnimalId = animalId;
        FeedingDate = feedingDate;
        FoodType = foodType;
    }
}