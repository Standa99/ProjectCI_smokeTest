namespace TribesTests.EntitiesTest;
using dusicyon_midnight_tribes_backend.Models.Entities;

public class WorldTest
{
    [Theory]
    [MemberData(nameof(Data))]
    public void WorldInstanceTest(string value1)
    {
        var expected = new World(value1);

        var actualName = value1;
        
        Assert.Equal(expected.Name,actualName);
    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] {"Asgard"},
            new object[] {"PepaWorld"},
            new object[] {"Abungo"},
            
        };
}