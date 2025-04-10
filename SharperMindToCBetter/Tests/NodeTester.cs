using SharperMindToCBetter.Classes;

namespace SharperMindToCBetter.Tests;

public class NodeTester
{
    public static void TestPrintingFunction(int nodeCount)
    {
        for (var i = 0; i < nodeCount; i++)
        {
             var random = new Random();
             var randomNumber = random.Next(1001);
             Node node = new()
             {
                 Value = randomNumber
             };
             node.PrintNode();
             Console.WriteLine("Expected the value {0} with null Left and null Right", randomNumber);
        }
    }
}