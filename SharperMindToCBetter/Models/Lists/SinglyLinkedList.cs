using SharperMindToCBetter.Models.Nodes;

namespace SharperMindToCBetter.Models.Lists;

public class SinglyLinkedList
{
    private SingleLinkedNode? Head { get; set; }
    
    private SingleLinkedNode? Current { get; set; }

    public void AddValue(int value)
    {
        if (Head is null)
        {
            Head = new SingleLinkedNode { Value = value };
        }
        else
        {
            Current = Head;
            while (true)
            {
                if (Current.Next is null)
                {
                    Current.Next = new SingleLinkedNode { Value = value };
                    return;
                }
                Current = Current.Next;
            }
        }
    }

    public void RemoveValue(int value)
    {
        if (Head is null)
        {
            Console.WriteLine("SingleLinkedList is empty");
            return;
        }
        
        Current = Head;
        while (true)
        {
            if (Current.Value == value)
            {
                Current = null;
                Head = null;
                return;
            }

            if (Current.Next is null)
            {
                Console.WriteLine("Value doesn't exist in list");
                return;
            }

            if (Current.Next.Value == value)
            {
                if (Current.Next.Next is not null)
                {
                    Current.Next = Current.Next.Next;
                    Console.WriteLine("Removed Value");
                    return;
                }
                Current.Next = null;
                Console.WriteLine("Removed Value");
                return;
            }
            
            Current = Current.Next;
            
        }
    }

    public List<int> PrintList()
    {
        List<int> printedList = [];
        Current = Head;
        var count = 0;
        while (Current is not null)
        {
            printedList.Add(Current.Value);
            Console.WriteLine("Position: {0} with Value: {1}", count, Current.Value);
            count++;
            Current = Current.Next;
        }
        return printedList;
    }

    public void ClearList()
    {
        Head = null;
        Current = null;
        Console.WriteLine("List is now empty");
    }
}