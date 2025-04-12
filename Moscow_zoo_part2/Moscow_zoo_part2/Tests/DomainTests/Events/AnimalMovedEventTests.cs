using Moscow_zoo_part2.Domain.Events;
using Xunit;

namespace Moscow_zoo_part2.Tests.DomainTests.Events;

public class AnimalMovedEventTests
{
    [Fact]
    public void Constructor_SetsPropertiesCorrectly()
    {
        var animalId = Guid.NewGuid();
        var oldEnclosureId = Guid.NewGuid();
        var newEnclosureId = Guid.NewGuid();

        var @event = new AnimalMovedEvent(animalId, oldEnclosureId, newEnclosureId);

        Assert.Equal(animalId, @event.AnimalId);
        Assert.Equal(oldEnclosureId, @event.OldEnclosureId);
    }
}