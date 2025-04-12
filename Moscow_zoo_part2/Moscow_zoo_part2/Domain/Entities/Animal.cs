using Moscow_zoo_part2.Domain.ValueObjects;

namespace Moscow_zoo_part2.Domain.Entities;

public class Animal
{
    public Guid Id { get; private set; }
    public string Species { get; private set; }
    public string Name { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Gender Gender { get; private set; }
    public FoodType FavoriteFood { get; private set; }
    public bool isHealthy { get; private set; }
    public Guid EnclosureId { get; private set; }

    public Animal(string species, string name,
        DateTime birthDate, Gender gender,
        FoodType favoriteFood)
    {
        Id = Guid.NewGuid();
        Species = species;
        Name = name;
        BirthDate = birthDate;
        Gender = gender;
        FavoriteFood = favoriteFood;
        isHealthy = true;
    }

    public void Feed()
    {
        isHealthy = true;
    }

    public void Heal()
    {
        isHealthy = true;
    }

    public void MoveToEnclosure(Guid enclosureId)
    {
        EnclosureId = enclosureId;
    }
    
}