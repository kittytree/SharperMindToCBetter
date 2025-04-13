using SharperMindToCBetter.Models.Trees;

namespace SharperTestsToCBetter;

public class BinarySearchTreeTest
{
    [SetUp]
    public void Setup()
    {
        BinarySearchTree toTestBst = new();
        var count = 0;
        
        toTestBst.InsertValue(50);
        count++;
        toTestBst.InsertValue(35);
        count++;
        toTestBst.InsertValue(75);
        count++;
        
        toTestBst.InsertValue(10);
        count++;
        toTestBst.InsertValue(45);
        count++;
        toTestBst.InsertValue(60);
        count++;
        toTestBst.InsertValue(100);
        //silence warning
        Console.WriteLine(count);
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}