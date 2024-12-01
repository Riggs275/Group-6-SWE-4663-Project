

namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class RequirementUnitTests {
    
    [Test]
    public void SetRequirementPriority_PriorityChangedCorrectly_ReturnsConfirmation() {
        //arrange
        Requirement newRequirement = new Requirement();
        string expectedConfirm = "Priority successfully changed!";
        //act
        string confirmation = newRequirement.SetImportance("low") ;
        //assert
        Assert.That(confirmation.Equals(expectedConfirm));
    }
    
    [Test]
    public void SetRequirementStatus_Not_Started_ReturnsSuccess() {
        
        // Arrange
        const string input = "NotStarted";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.NotStarted;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetRequirementStatus(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.requirementStatus == expectedStatus);
    }
    
    [Test]
    public void SetRequirementStatus_in_progress_ReturnsSuccess() {
        
        // Arrange
        const string input = "inprogress";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.InProgress;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetRequirementStatus(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.requirementStatus == expectedStatus);
    }
    
    [Test]
    public void SetRequirementStatus_ON_HOLD_ReturnsSuccess() {
        
        // Arrange
        const string input = "ONHOLD";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.OnHold;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetRequirementStatus(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.requirementStatus == expectedStatus);
    }
    
    [Test]
    public void SetRequirementStatus_coMpleTEd_ReturnsSuccess() {
        
        // Arrange
        const string input = "coMpleTEd";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.Completed;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetRequirementStatus(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.requirementStatus == expectedStatus);
    }
    
    [Test]
    public void SetRequirementStatus_Mitigated_ReturnsError() {
        
        // Arrange
        const string input = "Mitigated";
        const string expectedString = "That is not a valid status";
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetRequirementStatus(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
    }
    
    [Test]
    public void SetImportance_CRITICAL_ReturnsSuccess() {
        
        // Arrange
        const string input = "CRITICAL";
        const string expectedString = "Priority successfully changed!";
        const Priority expectedImportance = Priority.Critical;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetImportance(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.importance == expectedImportance);
    }
    
    [Test]
    public void SetImportance_high_ReturnsSuccess() {
        
        // Arrange
        const string input = "high";
        const string expectedString = "Priority successfully changed!";
        const Priority expectedImportance = Priority.High;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetImportance(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.importance == expectedImportance);
    }
    
    [Test]
    public void SetImportance_meDIum_ReturnsSuccess() {
        
        // Arrange
        const string input = "meDIum";
        const string expectedString = "Priority successfully changed!";
        const Priority expectedImportance = Priority.Medium;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetImportance(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.importance == expectedImportance);
    }
    
    [Test]
    public void SetImportance_LoW_ReturnsSuccess() {
        
        // Arrange
        const string input = "LoW";
        const string expectedString = "Priority successfully changed!";
        const Priority expectedImportance = Priority.Low;
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetImportance(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRequirement.importance == expectedImportance);
    }
    
    [Test]
    public void SetImportance_Not_Important_ReturnsError() {
        
        // Arrange
        const string input = "Not Important";
        const string expected = "That is not a valid Priority";
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetImportance(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetDescription_ProperValueDescription_ReturnsSuccess() {
        
        // Arrange
        const string description = "This is a description.";
        const string expected = "Description saved successfully!";
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetDescription(description);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetDescription_ExceededCharacterLimitDescription_ReturnsError() {
        
        // Arrange
        const string description = ("dbkpSHN4RcKxSh6k1aJ3SYJp8Aru2pYSAFijLqmPiYZQXM8xhXJpRXhcRDBzd1b8nXZY4TA4f45FzmU" +
                                    "h4nfaeXKB8UhBU49qdr5AKvjFmDA6ZJNByDkRuFC8k0TU3quijQL5CeQ9AV9tUTYq5Bp94MSdYvjDGR" +
                                    "ZF3NUArU2DEuQhiaS6TjUHbcbTE06B8URujPPYcau9VcqWumJbZmT4GVvhSgUau11WzdJBjGXjPt56N" +
                                    "XmJmGAEBdc56NM2hvyp6NCYKarwwMNN1LUVdLRBrGMTfL8vWtbymyQ9DCS1WN60P48YFy9w2A9LvxqC" +
                                    "QVzy9AKYBjzE6YYvryMQaV9JtEBEKfv1YcfCqGbzA8Ypr5WEqDwLZk5mWgikNJj0Ra60hLBMwC4mR1Z" +
                                    "M2gUJwj6GvPQ90Cvhdidgr9JCV95GRz1vG4SZxCAWgXyNpuXhrccmcS07DHAnFWfwTrHVGBmYPg1aFf" +
                                    "7n1kKxcLTQcqC85xYzhzfWRvkNjy6WnK9idiGmr7BPmgePrayK2Pbeut26eDwp64KtPf3LxHvcdmvWT" +
                                    "zXv1VJ7yBNJFEL52T6EuiQXedndTvvY22waNqpW1Wc75RnUBEUCFLawkENhqSTBxwVQyE8XPpDVbKET" +
                                    "nfFfPtaDakap1SqM3MLS3vTB8ChWLnenQjyLTHrJ6GzVemU2c8L9L3MShvKjMk1eptcKxug32QvYxdx" +
                                    "Nba2nSpyzpmuATSp7jWAvVGTSh8D65gR4BGXvabepxjmSZy0ajZzfrjUEgHCJpvMNygbybx35wYWRxx" +
                                    "8AUPPf5a7GnLxbhFt7TPCMutxK7gMDXSktHdXhKrc6AF8mW0Hwqxayc0PcPyD8St3qrygm0k4Y5vBC2" +
                                    "KgdKyPEyXzajuJxtytBQFaePaVDa0gg9L7F3J5QXLF2bjPvBKJVGcYYTHMPq8xNrBgQUVvBu6AiebeX" +
                                    "U42Jm8iJUhKjwXmD2Ar1n5XnYNKvDF6vX6E7Hxu1FWJTpRHKTbeM8");
        // Randomly generated string of size 1001
        const string expected = "Description length cannot exceed 1,000 characters!";
        Requirement testRequirement = new Requirement();
        
        // Act
        string result = testRequirement.SetDescription(description);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

}