using dusicyon_midnight_tribes_backend.Models.Entities;
using Type = dusicyon_midnight_tribes_backend.Models.Entities.Type;

namespace TribesTests.EntitiesTest;

public class ArmyTest
{
    [Theory]
    [MemberData(nameof(Data))]
    public void ArmyInstanceTest(int value1, string value2)
    {
        var actual = new Army(value1,value2);
        
        var expectedKingdomID = value1;
        var expectedlType = (Type)Enum.Parse(typeof(Type), value2,true);
        
        Assert.Equal(expectedKingdomID,actual.KingdomID);
        Assert.Equal(expectedlType,actual.Type);
    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {1,"attack"},
            new object[] {3,"defense"},
            new object[] {4,"attack"},
            
            //will fail if not attack or defense
        };
}