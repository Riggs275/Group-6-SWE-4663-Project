

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


    [Test]
    public void SetRequirementStatus_StatusChangedCorrectly_ReturnsConfirmation()
    {
        //arrange
        Requirement newRequirement = new Requirement();
        string expectedConfirm= "Status successfully changed!";
        //act
        string confirmation=newRequirement.setRequirementStatus("onhold");
        //assert
        Assert.That(confirmation.Equals(expectedConfirm));
    }
    [Test]
    public void SetRequirementPriority_PriorityChangedCorrectly_ReturnsConfirmation()
    {
        //arrange
        Requirement newRequirement = new Requirement();
        string expectedConfirm = "Priority successfully changed!";
        //act
        string confirmation = newRequirement.setImportance("low") ;
        //assert
        Assert.That(confirmation.Equals(expectedConfirm));
    }

}