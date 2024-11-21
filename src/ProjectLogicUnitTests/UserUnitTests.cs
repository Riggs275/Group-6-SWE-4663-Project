namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class UserUnitTests {
    
    [Test]
    public void UserConstructor_UserIsConstructedCorrectly_ReturnsInitializedFirstName() {
        
        //arrange
        User newUser=new User("Zachary","B","Powell",Role.Developer);
        string expectedName = "Zachary";
        
        //act
        string resultName = newUser.firstName;
        
        //assert
        Assert.That(resultName.Equals(expectedName));
    }

    [Test]
    public void SetFullName_FullNameSetCorrectly_ReturnsFullName() {
        
        //arrange
        User newUser = new User("Zachary","B","Powell",Role.Developer);
        string expectedName = "Zachary B. Powell";
        
        //act
        string resultName = newUser.GetFullName();
        
        //assert
        Assert.That(resultName.Equals(expectedName));
    }

    [Test]
    public void SetNewRole_RoleChangedToInput_ReturnsRoleSetCorrectly() {
        
        //arrange
        User newUser = new User();
        string expectedString = "Role set successfully!";
        
        //act
        string resultString=newUser.setRole("Developer");
        
        //assert
        Assert.That(resultString.Equals(expectedString));
    }

    [Test]
    public void SetFirstName_ProperValueName_ReturnsSuccess() {
        
        // Arrange
        const string expected = "User first name set successfully!";
        User testUser = new User();
        string input = "Izuku";
        
        // Act
        string result = testUser.setFirstName(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetFirstName_ExceededCharacterLimit_ReturnsError() {
        
        // Arrange
        const string expected = "New first name is too long, max length is 50 characters";
        User testUser = new User();
        string input = "All-Out Final Battle Super Saiyan Blue Goku & Super Saiyan Blue Vegeta";
        
        // Act
        string result = testUser.setFirstName(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetMiddleInitial_ProperValueName_ReturnsSuccess() {
        
        // Arrange
        const string expected = "User middle initial set successfully!";
        User testUser = new User();
        string input = "J";
        
        // Act
        string result = testUser.setMiddleInitial(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetMiddleInitial_ExceededCharacterLimit_ReturnsError() {
        
        // Arrange
        const string expected = "New middle initial is too long, max length is 2 characters";
        User testUser = new User();
        string input = "Three";
        
        // Act
        string result = testUser.setMiddleInitial(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetLastName_ProperValueName_ReturnsSuccess() {
        
        // Arrange
        const string expected = "User last name set successfully!";
        User testUser = new User();
        string input = "Midoriya";
        
        // Act
        string result = testUser.setLastName(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetLastName_ExceededCharacterLimit_ReturnsError() {
        
        // Arrange
        const string expected = "New last name is too long, max length is 50 characters";
        User testUser = new User();
        string input = "We Saiyans have no limits! Let's charge together at full power!";
        
        // Act
        string result = testUser.setLastName(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetRole_Lead_ReturnsSuccess() {
        
        // Arrange
        const string input = "Lead";
        const string expectedString = "Role set successfully!";
        const string expectedDescription = ("Responsible for overseeing the successful execution of project. " +
                                           "Makes high-level decisions, manages resources, and communicates " +
                                           "progress to higher management or clients.");
        const Role expectedRole = Role.Lead;
        User testUser = new User();
        
        // Act
        string result = testUser.setRole(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testUser.roleDescription.Equals(expectedDescription));
        Assert.That(testUser.userRole == expectedRole);
    }
    
    [Test]
    public void SetRole_developer_ReturnsSuccess() {
        
        // Arrange
        const string input = "developer";
        const string expectedString = "Role set successfully!";
        const string expectedDescription = ("Responsible for writing and maintaining code for the project. " +
                                            "Works closely with project manager and other team members to " +
                                            "ensure the project's success. Stays updated with the latest " +
                                            "technologies and best practices to ensure the quality and " +
                                            "efficiency of the project.");
        const Role expectedRole = Role.Developer;
        User testUser = new User();
        
        // Act
        string result = testUser.setRole(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testUser.roleDescription.Equals(expectedDescription));
        Assert.That(testUser.userRole == expectedRole);
    }
    
    [Test]
    public void SetRole_cODe_rEVIEWEr_ReturnsSuccess() {
        
        // Arrange
        const string input = "cODe rEVIEWEr";
        const string expectedString = "Role set successfully!";
        const string expectedDescription = ("Reviews the code written by developers to ensure it is of high " +
                                            "quality, adheres to best practices, and meets the project’s " +
                                            "standards.");
        const Role expectedRole = Role.CodeReviewer;
        User testUser = new User();
        
        // Act
        string result = testUser.setRole(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testUser.roleDescription.Equals(expectedDescription));
        Assert.That(testUser.userRole == expectedRole);
    }
    
    [Test]
    public void SetRole_TesteR_ReturnsSuccess() {
        
        // Arrange
        const string input = "TesteR";
        const string expectedString = "Role set successfully!";
        const string expectedDescription = ("Responsible for ensuring that the project meets all requirements " +
                                            "and functions as intended before it is released.");
        const Role expectedRole = Role.Tester;
        User testUser = new User();
        
        // Act
        string result = testUser.setRole(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testUser.roleDescription.Equals(expectedDescription));
        Assert.That(testUser.userRole == expectedRole);
    }
    
    [Test]
    public void SetRole_sTAKEholdER_ReturnsSuccess() {
        
        // Arrange
        const string input = "sTAKEholdER";
        const string expectedString = "Role set successfully!";
        const string expectedDescription = ("Responsible for defining the goals and requirements of the project. " +
                                            "May provide feedback during various phases of development, make " +
                                            "decisions about the direction of the project, and help resolve issues.");
        const Role expectedRole = Role.Stakeholder;
        User testUser = new User();
        
        // Act
        string result = testUser.setRole(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testUser.roleDescription.Equals(expectedDescription));
        Assert.That(testUser.userRole == expectedRole);
    }
    
    [Test]
    public void SetRole_User_ReturnsError() {
        
        // Arrange
        const string input = "User";
        const string expected = "That is not a valid role";
        User testUser = new User();
        
        // Act
        string result = testUser.setRole(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void GetFullName_NoMiddleInitial_ReturnsFirstandLast() {
        
        // Arrange
        const string expected = "Spongebob Squarepants";
        User testUser = new User();
        testUser.setFirstName("Spongebob");
        testUser.setLastName("Squarepants");
        
        // Act
        string result = testUser.GetFullName();
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void GetFullName_WithMiddleInitial_ReturnsFirstMiddleandLast() {
        
        // Arrange
        const string expected = "Sheldon J. Plankton";
        User testUser = new User();
        testUser.setFirstName("Sheldon");
        testUser.setMiddleInitial("J");
        testUser.setLastName("Plankton");
        
        // Act
        string result = testUser.GetFullName();
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void GetFullName_NoName_ReturnsError() {
        
        // Arrange
        const string expected = "First and/or last name isn't set";
        User testUser = new User();
        
        // Act
        string result = testUser.GetFullName();
        
        // Assert
        Assert.That(result.Equals(expected));
    }
}