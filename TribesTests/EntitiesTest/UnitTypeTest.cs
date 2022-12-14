using dusicyon_midnight_tribes_backend.Models.Entities;

namespace TribesTests.EntitiesTest;

public class UnitTypeTest
{
    [Theory]
    [MemberData(nameof(Data))]
    public void UnitInstanceTest(string value1, int value2, int value3, int value4)
    {
        var actual = new UnitType(value1, value2, value3, value4);
        
        var expectedName = value1;
        var expectedAttack = value2;
        var expectedDefense = value3;
        var expectedHpTotal = value4;
        
        Assert.Equal(expectedName,actual.Name);
        Assert.Equal(expectedAttack,actual.Attack);
        Assert.Equal(expectedDefense,actual.Defense);
        Assert.Equal(expectedHpTotal, actual.HPTotal);
    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {"Swordsman",3,4,10},
            new object[] {"Necromancer",4,5,33},
            new object[] {"Archer",5,34,22},
        };
}