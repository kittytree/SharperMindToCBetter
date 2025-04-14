namespace SharperMindToCBetter.Models.Nodes;

public class DoublyLinkedNode : Node
{
    public DoublyLinkedNode? Next { get; set; }
    public DoublyLinkedNode? Prev { get; set; }
}