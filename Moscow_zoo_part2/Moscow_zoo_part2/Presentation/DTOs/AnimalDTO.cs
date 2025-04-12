using Moscow_zoo_part2.Domain.ValueObjects;

namespace Moscow_zoo_part2.Presentation.DTOs;

public class AnimalDTO
{
    public Guid Id { get; set; }
    public string Species { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; }
    public FoodType FavoriteFood { get; set; }
    public bool IsHealthy { get; set; }
    public Guid CurrentEnclosureId { get; set; }
    
}


