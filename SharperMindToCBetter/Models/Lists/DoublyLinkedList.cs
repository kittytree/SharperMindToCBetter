using SharperMindToCBetter.Models.Nodes;

namespace SharperMindToCBetter.Models.Lists;

public class DoublyLinkedList 
{
    private DoublyLinkedNode? Head { get; set; }
    private DoublyLinkedNode? Tail { get; set; }
    public void AddValue(int value)
    {
        if (Head is null || Tail is null)
        {
            Head = new DoublyLinkedNode { Value = value };
            Tail = Head;
            return;
        }
        
        var toAddNode = new DoublyLinkedNode
        {
            Value = value,
            Prev = Tail
        };
        Tail.Next = toAddNode;
        Tail = toAddNode;
    }

    public void DeleteValue(int value)
    {
        if (Head is null || Tail is null)
        {
            Console.WriteLine("Can't delete value because list is empty");
            return;
        }
        
        var current  = Head;
        while (true)
        {
            if (current is null)
            {
                Console.WriteLine("Value not found");
                return;
            }
            if (current.Value == value)
            {
                Console.WriteLine("Found value to delete");
                var prevIsNull = current.Prev is null;
                var nextIsNull = current.Next is null;
                switch ((prevIsNull, nextIsNull))
                {
                    case (true, true):
                        Head = null;
                        Tail = null;
                        break;
                    case (false, true):
                        Tail = current.Prev;
                        if (Tail is null) return; // silencing compiler warning even though I'm somewhat sure this isn't possible.
                        Tail.Next = null;
                        break;
                    case (true, false):
                        Head = current.Next;
                        if (current.Next is null) return; // silencing compiler warning even though I'm somewhat sure this isn't possible.
                        current.Next.Prev = null;
                        break;
                    case (false, false):
                        if (current.Next is null) return; // silencing compiler warning even though I'm somewhat sure this isn't possible.
                        if (current.Prev is null) return;// silencing compiler warning even though I'm somewhat sure this isn't possible.
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                        break;
                }
                return;
            }

            if (current.Next is null)
            {
                Console.WriteLine("Value not found");
                return;
            }

            current = current.Next;
        }
    }
    
    public List<int> PrintList()
    {
        if (Head is null || Tail is null)
        {
            Console.WriteLine("List is empty");
            return [];
        }
        
        List<int> printedList = [];
        var current = Head;
        var count = 0;
        while (current is not null)
        {
            printedList.Add(current.Value);
            Console.WriteLine("Position: {0} with Value: {1}", count, current.Value);
            count++;
            current = current.Next;
        }
        return printedList;
    }

    public void ClearList()
    {
        Head = null;
        Console.WriteLine("List is now empty");
    }    
}