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
    
    // needed help https://www.youtube.com/watch?v=UcOxGmj45AA
    // got too caught up in tryna do this recursively without tracking parent while thinking i needed to track parent
    // video boinked me on the head with tracking parent and i felt dumb
    // not ashamed to learn from mistakes though.

    public bool DeleteValue(int value)
    {
        var currentNode = Root;
        var parentNode = Root;
        var isLeftChild = true;

        if (currentNode is null || parentNode is null) return false;

        while (currentNode is not null && !currentNode.IsEqual(value))
        {
            parentNode = currentNode;
            if (currentNode.IsGreater(value))
            {
                isLeftChild = true;
                currentNode = currentNode.Left;
                continue;
            }
            isLeftChild = false;
            currentNode = currentNode.Right;
        }
        
        if (currentNode is null) return false;
        if (!currentNode.IsEqual(value)) return false;
        
        /*
         * Case 1 no children
         * Case 2 One Child
         * Case 3 Two Children :c
         */

        if (currentNode.Right is null && currentNode.Left is null)
        {
            if (currentNode == Root)
            {
                Root = null;
                return true;
            }
            
            if (isLeftChild)
            {
                parentNode.Left = null;
                return true;
            }

            parentNode.Right = null;
            return true;
        }

        if (currentNode.Right is not null ^ currentNode.Left is not null)
        {
            if (currentNode.Right is not null)
            {
                if (isLeftChild)
                {
                    if (currentNode == Root)
                    {
                        Root = currentNode.Right;
                        return true;
                    }
                    parentNode.Left = currentNode.Right;
                    return true;
                }
                if (currentNode == Root)
                {
                    Root = currentNode.Right;
                    return true;
                }
                
                parentNode.Right = currentNode.Right;
                return true;
            }
            
            if (isLeftChild)
            {
                if (currentNode == Root)
                {
                    Root = currentNode.Left;
                    return true;
                }
                parentNode.Left = currentNode.Left;
                return true;
            }
            if (currentNode == Root)
            {
                Root = currentNode.Left;
                return true;
            }
                
            parentNode.Right = currentNode.Left;
            return true;
        }
        
        // Two child case
        
        var replacementNode = GetReplacementNode(currentNode);

        if (currentNode == Root)
        {
            Root = replacementNode;
        } else if (isLeftChild)
        {
            parentNode.Left = replacementNode;
        }else
        {
            parentNode.Right = replacementNode;
        }

        replacementNode.Left = currentNode.Left;

        return true;
    }

    private static BasicTreeNode GetReplacementNode(BasicTreeNode replaceNode)
    {
        var replacementParentNode = replaceNode; 
        var replacementNode = replaceNode;
        
        var currentNode = replaceNode.Right;
        
        while (currentNode is not null)
        {
            replacementParentNode = replacementNode;
            replacementNode = currentNode; 
            
            currentNode = currentNode.Left;
        }

        if (replacementNode != replaceNode.Right)
        {
            replacementParentNode.Left = replacementNode.Right;
            replacementNode.Right = replaceNode.Right;
        }
        
        return replacementNode;
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