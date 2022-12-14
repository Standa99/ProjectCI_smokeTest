using dusicyon_midnight_tribes_backend.Models.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TribesTests.EntitiesTest;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(Data))]
    public void UnitInstanceTest(int value1, int value2, int value3, int value4, int value5, int value6,int value7)
    {
        var actual = new Unit(value1, value2, value3, value4, value5, value6)
        {
            HPCurrent = value7
        };
        //HP current cant be above HPTotal or Below 0

        var expectedUnitTypeId = value1;
        var expectedKingdomId = value2;
        var expectedArmyId = value3;
        var expectedAttack = value4;
        var expectedDefense = value5;
        var expectedHpTotal = value6;


        Assert.Equal(expectedUnitTypeId,actual.UnitTypeId);
        Assert.Equal(expectedKingdomId,actual.KingdomId);
        Assert.Equal(expectedArmyId,actual.ArmyId);
        Assert.Equal(expectedAttack,actual.Attack);
        Assert.Equal(expectedDefense,actual.Defense);
        Assert.Equal(expectedHpTotal,actual.HPTotal);
        Assert.InRange(actual.HPCurrent,0,expectedHpTotal); // im using "Assert.InRange" to know that HPCurrent doesnt go below 0 or above HPTotal
    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {1,3,4,10,20,100,1000},
            new object[] {2,4,5,33,21,200,-10},
            new object[] {3,5,34,22,25,300,400},
            
            
        };
}