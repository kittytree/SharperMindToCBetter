using SharperMindToCBetter.Models.Lists;

namespace SharperTestsToCBetter.Tests.Lists;

[TestFixture]
public class CyclicalLinkedListTests
{
    [Test]
    // Naming Convention - ClassName_MethodName_ExpectedResult
    public static void CyclicalLinkedLIst_Constructor_NoValuesFromEmptyList()
    {
        // Arrange
        var toTestList = new CyclicalLinkedList();
        
        // ACT       
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues.Count == 0) { Assert.Pass(); }
        else { Assert.Fail(); }
    }

    [Test]
    public static void CyclicalLinkedList_InputValue_OneValue()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT       
        toTestList.InsertValue(1);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1]) { Assert.Pass(); }
        else { Assert.Fail(); }   
    }

    [Test]
    public static void CyclicalLinkedList_InputValue_TwoValues()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT       
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        var actualValues = toTestList.PrintList();


        // Assert
        if (actualValues is [1,2]) { Assert.Pass(); }
        else { Assert.Fail(); }   
    }

    [Test]
    public static void CyclicalLinkedList_InputValue_TenValues()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT       
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        var actualValues = toTestList.PrintList();
        // Assert
        
        if (actualValues is [1,2,3,4,5,6,7,8,9,10]) { Assert.Pass(); }
        else { Assert.Fail(); }   
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_NoValueNoDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT       
        toTestList.DeleteValue(2);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is []) { Assert.Pass(); }
        else { Assert.Fail(); }   
    }

    [Test]
    public static void CyclicalLinkedList_DeleteValue_OneValueNoDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.DeleteValue(2);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1]) { Assert.Pass(); }
        else { Assert.Fail(); }  
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_OneValueOneDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.DeleteValue(1);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is []) { Assert.Pass(); }
        else { Assert.Fail(); }  
    }

    [Test]
    public static void CyclicalLinkedList_DeleteValue_TwoValuesNoDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.DeleteValue(3);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1,2]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }

    [Test]
    public static void CyclicalLinkedList_DeleteValue_TwoValuesOneDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.DeleteValue(2);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TwoValuesOneDeleteHead()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.DeleteValue(1);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [2]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TwoValuesTwoDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.DeleteValue(1);
        toTestList.DeleteValue(2);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is []) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesNoDelete()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(11);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1,2,3,4,5,6,7,8,9,10]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesOneDeleteHead()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(1);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [2,3,4,5,6,7,8,9,10]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesOneDeleteLast()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(10);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1,2,3,4,5,6,7,8,9]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesOneDeleteMiddle()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(5);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1,2,3,4,6,7,8,9,10]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesOneDeleteOneTwice()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(1);
        toTestList.DeleteValue(1);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [2,3,4,5,6,7,8,9,10]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesOneDeleteLastTwiceButOnce()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(10);
        toTestList.DeleteValue(10);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1,2,3,4,5,6,7,8,9]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesOneDeleteMiddleTwiceButOnce()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(5);
        toTestList.DeleteValue(5);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [1,2,3,4,6,7,8,9,10]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
    
    [Test]
    public static void CyclicalLinkedList_DeleteValue_TenValuesDeleteHeadLastAndMiddle()
    {
        var toTestList = new CyclicalLinkedList();
        
        // ACT  
        toTestList.InsertValue(1);
        toTestList.InsertValue(2);
        toTestList.InsertValue(3);
        toTestList.InsertValue(4);
        toTestList.InsertValue(5);
        toTestList.InsertValue(6);
        toTestList.InsertValue(7);
        toTestList.InsertValue(8);
        toTestList.InsertValue(9);
        toTestList.InsertValue(10);
        toTestList.DeleteValue(1);
        toTestList.DeleteValue(5);
        toTestList.DeleteValue(10);
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues is [2,3,4,6,7,8,9]) { Assert.Pass(); }
        else { Assert.Fail(); } 
    }
}