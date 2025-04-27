using SharperMindToCBetter.Interfaces.Nodes;

namespace SharperMindToCBetter.Models.Nodes;

public class Node : INode
{
    public int Value { get; set; }

    public virtual void PrintNode() => Console.WriteLine("Node has a value of {0}", Value);
    public virtual bool IsGreater(Node toCompareNode) => Value > toCompareNode.Value;
    public virtual bool IsGreater(int toCompareValue) => Value > toCompareValue;
    public virtual bool IsLesser(Node toCompareNode) => Value < toCompareNode.Value;
    public virtual bool IsLesser(int toCompareValue) => Value < toCompareValue;
    public virtual bool IsEqual(Node toCompareNode) => Value == toCompareNode.Value;
    public virtual bool IsEqual(int toCompareValue) => Value == toCompareValue;
}