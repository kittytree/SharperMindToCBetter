using SharperMindToCBetter.Models.Trees;

namespace SharperTestsToCBetter.Tests.Trees;

[TestFixture]
public class BinarySearchTreeTests
{
    [Test]
    public static void BST_Constructor_NoValuesFromEmptyList()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues.Count == 0) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_OneValueFromOneInsertion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(1);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [1]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_NoValuesFromOneDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(1);
        toTestList.DeleteValue(1);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues.Count == 0) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_OneValueFromOneFalseDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(1);
        toTestList.DeleteValue(2);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [1]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_ThreeInsertsInOrder()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(2);
        toTestList.InsertValue(1);
        toTestList.InsertValue(3);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [1,2,3]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_ThreeInsertsInOrderLeftDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(2);
        toTestList.InsertValue(1);
        toTestList.InsertValue(3);
        toTestList.DeleteValue(1);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [2,3]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_ThreeInsertsInOrderRightDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(2);
        toTestList.InsertValue(1);
        toTestList.InsertValue(3);
        toTestList.DeleteValue(3);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [1,2]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_ThreeInsertsInOrderHeadDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(2);
        toTestList.InsertValue(1);
        toTestList.InsertValue(3);
        toTestList.DeleteValue(2);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [1,3]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
        
    [Test]
    public static void BST_Constructor_ThreeInsertsInOrderTwoHeadDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(2);
        toTestList.InsertValue(1);
        toTestList.InsertValue(3);
        toTestList.DeleteValue(2);
        toTestList.DeleteValue(1);
        
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [3]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_ThreeInsertsInOrderThreeHeadDeletion()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(2);
        toTestList.InsertValue(1);
        toTestList.InsertValue(3);
        toTestList.DeleteValue(2);
        toTestList.DeleteValue(1);
        toTestList.DeleteValue(3);
        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is []) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
    [Test]
    public static void BST_Constructor_SevenInsertionInOrder()
    {
        // Arrange
        var toTestList = new BinarySearchTree();
        toTestList.InsertValue(50);
        toTestList.InsertValue(25);
        toTestList.InsertValue(75);
        toTestList.InsertValue(10);
        toTestList.InsertValue(30);
        toTestList.InsertValue(65);
        toTestList.InsertValue(85);

        // ACT       
        var actualValues = toTestList.PrintInOrder();

        // Assert
        if (actualValues is [10,25,30,50,65,75,85]) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
    
}