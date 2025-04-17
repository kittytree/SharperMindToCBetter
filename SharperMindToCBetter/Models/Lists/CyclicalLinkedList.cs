/*
 * Q: Why not use a count variable?
 * A: Because it was more fun to try and do it without a count cause head is an object, and you don't need a count.
 */

using SharperMindToCBetter.Models.Nodes;

namespace SharperMindToCBetter.Models.Lists;

public class CyclicalLinkedList
{
    private DoublyLinkedNode? Head { get; set; }

    public void InsertValue(int value)
    {
        if (Head is null)
        {
            Head = new DoublyLinkedNode { Value = value };
            Head.Prev = Head;
            Head.Next = Head;
            return;
        }
        var toAddNode = new DoublyLinkedNode { Value = value };
        switch (Head.Prev == Head)
        {
            case true:
                Head.Prev = toAddNode;
                Head.Next = toAddNode;
                toAddNode.Next = Head;
                toAddNode.Prev = Head;
                break;
            case false:
                toAddNode.Next = Head;
                toAddNode.Prev = Head.Prev;
                if (Head.Prev is not null) Head.Prev.Next = toAddNode; // silence compiler dereference warning
                Head.Prev = toAddNode;
                break;
        }
    }

    public void DeleteValue(int value)
    {
        var current = Head;
        if (current is null)
        {
            Console.WriteLine("Cannot delete node because cyclical linked list is empty.");
            return;
        }

        if (current.Value == value && Head is not null)
        {
            if (Head.Next == Head)
            {
                Head = null;
                return;
            }
            current = current.Next;
            if (current == null) return; // silencing compiler de-reference warning, un-needed in cyclical list.
            current.Prev = Head.Prev;
            if (Head.Prev != null) Head.Prev.Next = current; // silencing compiler de-reference warning, un-needed in cyclical list.
            Head = current;

            return;
        }
        
        current = current.Next;
        while (current is not null  && current != Head)
        {
            if (current.Value != value)
            {
                current = current.Next;
                continue;
            }

            if (current.Prev == current)
            {
                Head = null;
                Console.WriteLine("Value has been deleted.");
                return;
            }

            if (current.Prev is null) continue;
            current.Prev.Next = current.Next;
            if (current.Next != null) current.Next.Prev = current.Prev; // silencing compiler de-reference warning, un-needed in cyclical list.
            Console.WriteLine("Value has been deleted.");
            return;
        }
        Console.WriteLine("Value was not found in the list, and thus not deleted.");
    }

    public List<int> PrintList()
    {
        var count = 0;
        var current = Head;
        List<int> list = [];
        
        if (current is null)
        {
            Console.WriteLine("Cannot list node because cyclical linked list is empty.");
            return list;
        }
        
        Console.WriteLine("Count: {0} with Value: {1}", count, current.Value);
        list.Add(current.Value);
        current = current.Next;
        count++;
        
        while ( current != Head && current is not null )
        {
            list.Add(current.Value);
            Console.WriteLine("Count: {0} with Value: {1}", count, current.Value);
            current = current.Next;
            count++;
        }
        
        return list;
    }
    
}