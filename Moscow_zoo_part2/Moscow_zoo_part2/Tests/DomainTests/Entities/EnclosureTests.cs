using Moscow_zoo_part2.Domain.Entities;
using Xunit;

namespace Moscow_zoo_part2.Tests.DomainTests.Entities;

public class EnclosureTests
{
    [Fact]
    public void AddAnimal_WhenEnclosureIsFull_ThrowsException()
    {
        // Arrange
        var enclosure = new Enclosure("Для хищников", size: 100, currentCapacity: 2, maxCapacity: 2);
        var animalId = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => enclosure.AddAnimal(animalId));
    }

    [Fact]
    public void AddAnimal_WhenEnclosureHasSpace_IncreasesCurrentCapacity()
    {
        var enclosure = new Enclosure("Для травоядных", 100, 1, 3);
        var animalId = Guid.NewGuid();

        enclosure.AddAnimal(animalId);

        Assert.Equal(2, enclosure.CurrentCapacity);
    }
}