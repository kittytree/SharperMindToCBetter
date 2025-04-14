using SharperMindToCBetter.Models.Nodes;

namespace SharperMindToCBetter.Models.Trees;

public class BinarySearchTree
{
    private int Count { get; set; }
    private BasicTreeNode? Root { get; set; }

    
    public void InsertValue(int value)
    {
        BasicTreeNode toInsert = new() { Value = value };
        InsertNode(toInsert);
    }
    private void InsertNode(BasicTreeNode node)
    {
        Count++;
        
        if (Root is null)
        {
            Root = node;
            return;
        }

        var currentNode = Root;    
        
        while (true)
        {
            if (currentNode.IsGreater(node) )
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode.Left = node;
                    return;
                }
            }
            else
            {
                if (currentNode.Right is not null)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode.Right = node;
                    return;
                }
            }
        }
    }

    // todo refactor so it's not a terrible mess
    public void DeleteValue(int value)
    {
        if (Root is null)
        {
            Console.WriteLine("Tree is empty");
            return;
        }

        Count--;

        if (Root.IsEqual(value))
        {
            if (Root.Left is null && Root.Right is null)
            {
                Root = null;
                Console.WriteLine("Root Deleted, Tree is now empty");
                return;
            }

            if (Root.Left is not null && Root.Right is null)
            {
                Root = Root.Left;
                Console.WriteLine("Value deleted");
                return;
            }else if (Root.Left is null && Root.Right is not null)
            {
                Root = Root.Right;
                Console.WriteLine("Value deleted");
                return;
            }

            if (Root.Right is null) return; // silencing compiler warning even though I'm somewhat sure this isn't possible.
            var nextInPlaceNode = GetNextInOrderNode(Root.Right);
            nextInPlaceNode.Left = Root.Left;
            nextInPlaceNode.Right = Root.Right;
            Root = nextInPlaceNode;
            Console.WriteLine("Value deleted");
            return;
        }

        var parentOfValueToFind = FindParentOfValue(value, Root);
        if (parentOfValueToFind is null)
        {
            Console.WriteLine("Value not found");
            return;
        }
        
        DeleteValue(value, parentOfValueToFind);
    }
    
    // todo refactor so it's not a terrible mess

    private static BasicTreeNode? FindParentOfValue(int value, BasicTreeNode currentNode)
    {
        if (currentNode.Left is null && currentNode.Right is null)
        {
            return null;
        }
        
        var parentIsGreaterThanValue = currentNode.IsGreater(value);

        if (parentIsGreaterThanValue)
        {
            if (currentNode.Left is null)
            {
                return null;
            }

            if (currentNode.Left.IsEqual(value))
            {
                return currentNode.Left;
            }
            
            return FindParentOfValue(value, currentNode.Left);
        }
        else
        {
            if (currentNode.Right is null)
            {
                return null;
            }

            if (currentNode.Right.IsEqual(value))
            {
                return currentNode.Right;
            }
            
            return FindParentOfValue(value, currentNode.Right);
        }
        
    }
    private static BasicTreeNode FindNodeRecursive(int value, BasicTreeNode currentNode)
    {
        if (currentNode.IsEqual(value)) return currentNode;
        
        if (currentNode.IsGreater(value)) return (currentNode.Left is null)?  currentNode : FindNodeRecursive(value, currentNode.Left);
        
        return (currentNode.Right is null)?  currentNode : FindNodeRecursive(value, currentNode.Right);
    }

    // todo refactor so it's not a terrible mess

    private static bool DeleteValue(int value, BasicTreeNode currentNode)
    {
        var isParentGreatThanValue = currentNode.IsGreater(value);

        if (isParentGreatThanValue)
        {
            // null case
            if (currentNode.Left is null)
            {
                Console.WriteLine("Value not found");
                return false;
            }

            // case 1: no children
            if (currentNode.Left.Left is null && currentNode.Left.Right is null)
            {
                currentNode.Left = null;
                Console.WriteLine("Value deleted");
                return true;
            }
            
            // case 2: 1 child
            if (currentNode.Left.Left is not null && currentNode.Left.Right is not null)
            {
                currentNode.Left = currentNode.Left.Left;
                Console.WriteLine("Value deleted");
                return true;
            }
            else if (currentNode.Left.Left is null && currentNode.Left.Right is not null)
            {
                currentNode.Left = currentNode.Left.Right;
                Console.WriteLine("Value deleted");
                return true;
            }
            
            // case 3: both children
            var toReplaceNode = GetNextInOrderNode(currentNode.Left);

            toReplaceNode.Left = currentNode.Left.Left;
            toReplaceNode.Right = currentNode.Left.Right;

            currentNode.Left = toReplaceNode;
        }
        else
        {
            if (currentNode.Right is null)
            {
                Console.WriteLine("Value not found");
                return false;
            }

            // case 1: no children
            if (currentNode.Right.Left is null && currentNode.Right.Right is null)
            {
                currentNode.Right = null;
                Console.WriteLine("Value deleted");
                return true;
            }
            
            // case 2: 1 child
            if (currentNode.Right.Left is not null && currentNode.Right.Right is not null)
            {
                currentNode.Right = currentNode.Right.Left;
                Console.WriteLine("Value deleted");
                return true;
            }
            else if (currentNode.Right.Left is null && currentNode.Right.Right is not null)
            {
                currentNode.Right = currentNode.Right.Right;
                Console.WriteLine("Value deleted");
                return true;
            }
            
            // case 3: both children
            var toReplaceNode = GetNextInOrderNode(currentNode.Right);

            toReplaceNode.Left = currentNode.Right.Left;
            toReplaceNode.Right = currentNode.Right.Right;

            currentNode.Right = toReplaceNode;
        }

        Console.WriteLine("Value deleted");
        return true;
    }

    private static BasicTreeNode GetNextInOrderNode(BasicTreeNode currentNode)
    {
        switch (currentNode.Left)
        {
            // Base case on first loop
            case null when currentNode.Right is null:
            case null:
                return currentNode;
        }

        if (currentNode.Left.Left is null)
        {
            var tempNode = currentNode.Left;
            currentNode.Left = currentNode.Left.Right;
            tempNode.Right = null;
            return tempNode;
        }
        else
        {
            return GetNextInOrderNode(currentNode.Left);
        }
    }
    
    public List<int> PrintInOrder()
    {
        if (Root is not null) return PrintInOrderRecursively(Root, []);
        Console.WriteLine("No root node");
        return [];
    }

    private static List<int> PrintInOrderRecursively(BasicTreeNode currentNode, List<int> printedValues)
    {
        if (currentNode.Left is not null)
        {
            PrintInOrderRecursively(currentNode.Left, printedValues);
        }
    
        printedValues.Add(currentNode.Value);
        currentNode.PrintNode();

        if (currentNode.Right is not null)
        {
            PrintInOrderRecursively(currentNode.Right, printedValues);
        }
        return printedValues;
    }
    
    public List<int> PrintPreOrder()
    {
        if (Root is not null) return PrintPreOrderRecursively(Root, []);
        Console.WriteLine("No root node");
        return [];
    }

    private static List<int> PrintPreOrderRecursively(BasicTreeNode currentNode, List<int> printedValues)
    {
        printedValues.Add(currentNode.Value);
        currentNode.PrintNode();

        if (currentNode.Left is not null)
        {
            PrintPreOrderRecursively(currentNode.Left, printedValues);
        }

        if (currentNode.Right is not null)
        {
            PrintPreOrderRecursively(currentNode.Right, printedValues);
        }
        
        return printedValues;
    }
    
    
    public List<int> PrintPostOrder()
    {
        if (Root is not null) return PrintPostOrderRecursively(Root, []);
        Console.WriteLine("No root node");
        return [];
    }

    private static List<int> PrintPostOrderRecursively(BasicTreeNode currentNode, List<int> printedValues)
    {
        if (currentNode.Left is not null)
        {
            PrintPostOrderRecursively(currentNode.Left, printedValues);
        }

        if (currentNode.Right is not null)
        {
            PrintPostOrderRecursively(currentNode.Right, printedValues);
        }

        printedValues.Add(currentNode.Value);
        currentNode.PrintNode();
        return printedValues;
    }
}