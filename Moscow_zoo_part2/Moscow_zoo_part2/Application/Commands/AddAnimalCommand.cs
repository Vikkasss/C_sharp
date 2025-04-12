using Moscow_zoo_part2.Domain.ValueObjects;
using MediatR;
namespace Moscow_zoo_part2.Application.Commands;

public class AddAnimalCommand : IRequest<Unit>
{
    public string Species {get; set;}
    public string Name {get; set;}
    public DateTime DateOfBirth {get; set;}
    public Gender Gender {get; set;}
    public FoodType FavoriteFood {get; set;}

    public AddAnimalCommand(string species, string name, DateTime dateOfBirth, Gender gender, FoodType foodType)
    {
        Species = species;
        Name = name;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        FavoriteFood = foodType;
    }
    
    
}