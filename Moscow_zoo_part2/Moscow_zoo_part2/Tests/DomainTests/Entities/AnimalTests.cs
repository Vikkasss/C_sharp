using Moscow_zoo_part2.Domain.Entities;
using Moscow_zoo_part2.Domain.ValueObjects;
using Xunit;
namespace Moscow_zoo_part2.Tests.DomainTests.Entities;

public class AnimalTests
{
    [Fact]
    public void MoveToEnclosure_SetsNewEnclosureId()
    {
        var animal = new Animal("Лев", "Симба", DateTime.Now, Gender.Male, FoodType.Meat);
        var enclosureId = Guid.NewGuid();

        animal.MoveToEnclosure(enclosureId);

        Assert.Equal(enclosureId, animal.EnclosureId);
    }

}