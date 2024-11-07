

namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class RequirementUnitTests {
    [Test]
    public void SetRequirementsDescription_NewRequirementDescriptionSetCorrectly_ReturnsNewDescription()
    {
        //arrange
        Requirement newRequirement = new Requirement();
        string expectedDescription="Test description";
        //act
        string resultDescription = newRequirement.SetDescription("Test description");
        //assert
        Assert.That(resultDescription.Equals(expectedDescription));
    }
    

}