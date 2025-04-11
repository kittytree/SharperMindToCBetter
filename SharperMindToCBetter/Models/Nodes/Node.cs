using SharperMindToCBetter.Interfaces.Nodes;

namespace SharperMindToCBetter.Models.Nodes;

public class Node : INode
{
    public int Value { get; set; }

    public virtual void PrintNode()
    {
        Console.WriteLine("Node has a value of {0}", Value);
    }
}