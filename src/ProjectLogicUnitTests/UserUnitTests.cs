namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class UserUnitTests {
    [Test]
    public void UserConstructor_UserIsConstructedCorrectly_ReturnsInitializedFirstName()
    {
        //arrange
        User newUser=new User("Zachary","B","Powell",Role.Developer);
        string expectedName = "Zachary";
        //act
        string resultName = newUser.firstName;
        //assert
        Assert.That(resultName.Equals(expectedName));
    }

    [Test]
    public void SetName_UserNameIsSetCorrectly_FullNameIsReturnedOnSetNameMethod()
    {
        //arrange
        User newUser = new User();
        string expectedName = "Zachary B Powell";

        //act
        string resultFullName=newUser.setName("Zachary", "B", "Powell");
        //assert
        Assert.That(resultFullName.Equals(expectedName));
    }


    [Test]
    public void SetRoleDescription_RoleDescriptionUpdatedToNewDescription_ReturnsNewDescription()
    {
        //arrange
        User newUser= new User();
        string ExpectedDescription = "Test description";

        //act
        string resultDescription = newUser.setRoleDescription("Test description");

        //assert
        Assert.That(resultDescription.Equals(ExpectedDescription));
    }



    [Test]
    public void SetFullName_FullNameSetCorrectly_ReturnsFullName()
    {
        //arrange
        User newUser = new User("Zachary","B","Powell",Role.Developer);
        string expectedName = "Zachary B. Powell";
        //act
        string resultName = newUser.GetFullName();
        //assert
        Assert.That(resultName.Equals(expectedName));
    }

}