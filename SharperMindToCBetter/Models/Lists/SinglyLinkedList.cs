using SharperMindToCBetter.Models.Nodes;

namespace SharperMindToCBetter.Models.Lists;

public class SinglyLinkedList
{
    private SingleLinkedNode? Head { get; set; }
    public void InsertValue(int value)
    {
        if (Head is null)
        {
            Head = new SingleLinkedNode { Value = value };
        }
        else
        {
            var current = Head;
            while (true)
            {
                if (current.Next is null)
                {
                    current.Next = new SingleLinkedNode { Value = value };
                    return;
                }
                current = current.Next;
            }
        }
    }

    public void DeleteValue(int value)
    {
        if (Head is null)
        {
            Console.WriteLine("SingleLinkedList is empty");
            return;
        }
        
        var  current = Head;
        while (true)
        {
            if (current.Value == value)
            {
                current = null;
                Head = null;
                return;
            }

            if (current.Next is null)
            {
                Console.WriteLine("Value doesn't exist in list");
                return;
            }

            if (current.Next.Value == value)
            {
                if (current.Next.Next is not null)
                {
                    current.Next = current.Next.Next;
                    Console.WriteLine("Removed Value");
                    return;
                }
                current.Next = null;
                Console.WriteLine("Removed Value");
                return;
            }
            
            current = current.Next;
            
        }
    }

    public List<int> PrintList()
    {
        if (Head is null)
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