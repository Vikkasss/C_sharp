using Moscow_zoo_part2.Domain.ValueObjects;

namespace Moscow_zoo_part2.Domain.Entities;

public class FeedingSchedule
{
    public Guid Id { get; private set; }
    public Guid AnimalId { get; private set; }
    public DateTime FeedingTime { get; private set; }
    public FoodType FoodType { get; private set; }
    public bool IsCompleted { get; private set; }

    public FeedingSchedule(Guid animalId, DateTime feedingTime, FoodType foodType)
    {
        Id = Guid.NewGuid();
        AnimalId = animalId;
        FeedingTime = feedingTime;
        FoodType = foodType;
        IsCompleted = false;
    }

    public void ChangeSchedule(DateTime newFeedingTime, FoodType newFoodType)
    {
        FeedingTime = newFeedingTime;
        FoodType = newFoodType;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }
    
}