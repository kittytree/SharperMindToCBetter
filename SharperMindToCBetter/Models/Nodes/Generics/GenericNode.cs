namespace SharperMindToCBetter.Models.Nodes.Generics;

public class GenericNode<T> where T: IComparable<T>
{
    public T? Value { get; set; } = default;

    public virtual void PrintNode() => Console.WriteLine("Node has a value of {0}", Value);
    
    public virtual bool IsGreater(GenericNode<T> toCompareNode) => Value is not null &&
                                                                  toCompareNode.Value is not null &&
                                                                  Value.CompareTo(toCompareNode.Value) > 0;
    
    public virtual bool IsGreater(T toCompareValue) => Value is not null &&
                                                      Value.CompareTo(toCompareValue) > 0;
    
    public virtual bool IsLesser(GenericNode<T> toCompareNode) => Value is not null &&
                                                                  toCompareNode.Value is not null &&
                                                                  Value.CompareTo(toCompareNode.Value) < 0;
    
    public virtual bool IsLesser(T toCompareValue) => Value is not null &&
                                                      Value.CompareTo(toCompareValue) < 0;
    
    public virtual bool IsEqual(GenericNode<T> toCompareNode) => EqualityComparer<T>
                                                                    .Default
                                                                    .Equals(Value, toCompareNode.Value);
   
    public virtual bool IsEqual(T toCompareValue) => EqualityComparer<T>
                                                        .Default
                                                        .Equals(Value, toCompareValue);
}