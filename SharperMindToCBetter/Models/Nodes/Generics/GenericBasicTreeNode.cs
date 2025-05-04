namespace SharperMindToCBetter.Models.Nodes.Generics;

public class GenericBasicTreeNode<T> : GenericNode<T> where T: GenericNode<T>, IComparable<T>
{
    public GenericBasicTreeNode<T>? Left { get; set; }
    public GenericBasicTreeNode<T>? Right { get; set; }

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