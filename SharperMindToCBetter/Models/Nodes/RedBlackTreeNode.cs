using SharperMindToCBetter.Enums;

namespace SharperMindToCBetter.Models.Nodes;

public class RedBlackTreeNode : BasicTreeNode
{
    public RedBlack Colour { get; set; } = RedBlack.Red;

    public override void PrintNode()
    {
        var printNode = $"Value: {Value} Colour: {Colour}";
        
        printNode += (Left is null) switch
        {
            true => $" Left: Null",
            false => $" Left: {Left.Value}"
        };

        printNode += (Right is null) switch
        {
            true => $" Right: Null",
            false => $" Right: {Right.Value}"
        };
        
        Console.WriteLine(printNode);
    }
}