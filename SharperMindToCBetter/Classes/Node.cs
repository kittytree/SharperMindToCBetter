namespace SharperMindToCBetter.Classes;

public class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }

    public void PrintNode()
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