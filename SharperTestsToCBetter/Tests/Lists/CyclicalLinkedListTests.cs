using SharperMindToCBetter.Models.Lists;

namespace SharperTestsToCBetter.Tests.Lists;

[TestFixture]
public class CyclicalLinkedListTests
{
    [Test]
    // Naming Convention - ClassName_MethodName_ExpectedResult
    public static void CyclicalLinkedLIst_InputValue_NoValuesFromEmptyList()
    {
        // Arrange
        var toTestList = new CyclicalLinkedList();
        
        // ACT       
        var actualValues = toTestList.PrintList();

        // Assert
        if (actualValues.Count == 0) { Assert.Pass(); }
        else { Assert.Fail(); }
    }
}