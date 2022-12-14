namespace TribesTests.EntitiesTest;
using dusicyon_midnight_tribes_backend.Models.Entities;
public class KingdomTest
{
    [Theory]
    [MemberData(nameof(Data))]
    public void KingdomInstanceTest(int value1,string value2, int value3, int value4)
    {
        var actual = new Kingdom(value1,value2,value3,value4);

        var expectedWorld_Id = value1;
        var expectedName = value2;
        var expectedX = value3;
        var expectedY = value4;
        

        Assert.Equal(expectedWorld_Id,actual.WorldId);
        Assert.Equal(expectedName,actual.Name);
        Assert.Equal(expectedX,actual.Coordinate_X);
        Assert.Equal(expectedY,actual.Coordinate_Y);

       

    }
    
    public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1,"Avalon", 2, 3 },
            new object[] { 5,"Asgard", -6, -10 },
            new object[] { 8,"Trondheim", 2, 0 },
            
        };
}