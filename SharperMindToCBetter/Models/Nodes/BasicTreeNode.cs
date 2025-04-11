namespace SharperMindToCBetter.Models.Nodes;

public class BasicTreeNode : Node
{
    public BasicTreeNode? Left { get; set; }
    public BasicTreeNode? Right { get; set; }

    public override void PrintNode()
    {
        var printNode = $"Value: {Value}";
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