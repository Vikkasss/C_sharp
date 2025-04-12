using Microsoft.AspNetCore.Authorization.Infrastructure;
using Moscow_zoo_part2.Domain.ValueObjects;
using Xunit;

namespace Moscow_zoo_part2.Tests.DomainTests.ValueObjects;

public class ValueObjTests
{
    [Fact]
    public void FoodType_HasCorrectValues()
    {
        Assert.Equal(0, (int)FoodType.Carnivore);
        Assert.Equal(6, (int)FoodType.Fish);
    }

    [Fact]
    public void Gender_HasCorrectValues()
    {
        Assert.Equal(0, (int)Gender.Male);
        Assert.Equal(1, (int)Gender.Female);
    }
}