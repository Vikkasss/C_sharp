namespace Moscow_zoo_part2.Domain.Events;

public class AnimalMovedEvent
{
    public Guid AnimalId { get; set; }
    public Guid OldEnclosureId { get; set; }
    public Guid NewEnclosureId { get; set; }

    public AnimalMovedEvent(Guid animalId, Guid oldEnclosureId, Guid newEnclosureId)
    {
        AnimalId = animalId;
        OldEnclosureId = oldEnclosureId;
        NewEnclosureId = newEnclosureId;
    }
    
}