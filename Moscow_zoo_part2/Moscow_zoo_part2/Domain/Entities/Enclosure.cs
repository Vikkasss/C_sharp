namespace Moscow_zoo_part2.Domain.Entities;

public class Enclosure
{
    public Guid Id { get; private set; }
    public string Type { get; private set; }
    public int Size { get; private set; }
    public int CurrentCapacity { get; private set; }
    public int MaxCapacity { get; private set; }
    public List<Guid> Animals { get; private set; }

    public Enclosure(string type, int size, int currentCapacity, int maxCapacity)
    {
        Id = Guid.NewGuid();
        Type = type;
        Size = size;
        CurrentCapacity = currentCapacity;
        MaxCapacity = maxCapacity;
        Animals = new List<Guid>();
    }

    public void AddAnimal(Guid animalId)
    {
        if (CurrentCapacity >= MaxCapacity)
        {
            throw new InvalidOperationException("Enclosure was crowded");
        }
        Animals.Add(animalId);
        CurrentCapacity++;
    }

    public void RemoveAnimal(Guid animalId)
    {
        if (!Animals.Contains(animalId))
        {
            throw new InvalidOperationException("Animal do not founded in enclosure was");
        }
        Animals.Remove(animalId);
        CurrentCapacity--;
    }

    public void Clear()
    {
        Animals.Clear();
    }
    
}