using SharperMindToCBetter.Models.Trees;

Console.WriteLine("Trying out insert");

BinarySearchTree tree = new();

Console.WriteLine("------------------------------------------------------------");

tree.PrintInOrder();
/*
 *          50
 *    35             75
 * 10     45    60          100
 */
tree.InsertValue(50);
tree.InsertValue(35);
tree.InsertValue(75);
tree.InsertValue(10);
tree.InsertValue(45);
tree.InsertValue(60);
tree.InsertValue(100);

Console.WriteLine("------------------------------------------------------------");

tree.PrintInOrder();

Console.WriteLine("------------------------------------------------------------");

tree.DeleteValue(50);
Console.WriteLine("------------------------------------------------------------");
tree.PrintInOrder();

Console.WriteLine("------------------------------------------------------------");
/*Random rand = new();

for (var i = 0; i < 20; i++)
{
    var toInsertNum = rand.Next(10);
    Console.WriteLine("Trying insert {0}", toInsertNum);
    tree.InsertValue(toInsertNum);
}

Console.WriteLine("In Order before deletion");
tree.PrintInOrder();

Console.WriteLine("------------------------------------------------------------");

for (var i = 0; i < 15; i++)
{
    var toDeleteNum = rand.Next(10);
    Console.WriteLine("Trying deletion on {0}", toDeleteNum);
    tree.DeleteValue(toDeleteNum);
    
    Console.WriteLine("------------------------------------------------------------");

    Console.WriteLine("In Order");
    tree.PrintInOrder();

    Console.WriteLine("------------------------------------------------------------");
}*/


/*Console.WriteLine("------------------------------------------------------------");

Console.WriteLine("Pre Order");
tree.PrintPreOrder();*/

Console.WriteLine("------------------------------------------------------------");

Console.WriteLine("In Order");
tree.PrintInOrder();

Console.WriteLine("------------------------------------------------------------");

return;
Console.WriteLine("Post Order");
tree.PrintPostOrder();

Console.WriteLine("------------------------------------------------------------");