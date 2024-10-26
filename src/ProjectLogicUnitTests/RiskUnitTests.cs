namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class RiskUnitTests {

    [Test]
    public void SetName_ProperValueName_ReturnsSuccess() {
        
        // Arrange
        const string Name = "String of exactly 50 character to handle edge case";
        const string expected = "Name saved successfully!";
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.setName(Name);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetName_ExceededCharacterLimitName_ReturnsError() {
        
        // Arrange
        const string Name = "Risk 2: A string containing more than 51 characters for unit tests";
        const string expected = "Risk name cannot exceed 50 characters!";
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.setName(Name);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetDescription_ProperValueDescription_ReturnsSuccess() {
        
        // Arrange
        const string Description = "This risk pertains to the lead coder contracting a sickness such as COVID-19";
        const string expected = "Description saved successfully!";
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.setDescription(Description);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetDescription_ExceededCharacterLimitDescription_ReturnsError() {
        
        // Arrange
        const string Description = ("fMM6TaGALQrMXC3wqfafSgphTpcwkHKi6XXXUNgGnbTXfeSv4j6THUQ1DXfyYCRjtDZrbu0V3Rd8Cr" + 
                                    "N6JYvnZ5Hw2qG4trLfth1UDuQR9HyE6Uujgw70h8AXkHYmmTTYeTWnVyV7KeSXfiiX1r6u8pNvcQVp" +
                                    "BtzPgS69tPFUMdJW1X38NDxQ8nCD9qKpViGdbNB8qS8ntkzCZU2wkTAd0dbUfB4ADUq3TvK91we8FJ" +
                                    "iFN3dBw69pRwrD54ZvxfQWLH6KhYa6HcauZx9TEiJm76Q2HkwWEj7mZmNrmh9xLjLmgJKB7dPugLPe" +
                                    "DUd5rcwDXyEFaBdFaxC9TLBu5NmhJhKHE06KrGu");
        // Randomly generated string of size 351
        const string expected = "Description length cannot exceed 350 characters!";
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.setDescription(Description);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void ChangeRiskStatus_Active_ReturnsSuccess() {
        
        // Arrange
        const string Input = "Active";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.Active;
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.ChangeRiskStatus(Input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRisk.GetRiskStatus() == expectedStatus);
    }
    
    [Test]
    public void ChangeRiskStatus_mitigated_ReturnsSuccess() {
        
        // Arrange
        const string Input = "mitigated";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.Mitigated;
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.ChangeRiskStatus(Input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRisk.GetRiskStatus() == expectedStatus);
    }
    
    [Test]
    public void ChangeRiskStatus_rESOlvED_ReturnsSuccess() {
        
        // Arrange
        const string Input = "rESOLvED";
        const string expectedString = "Status successfully changed!";
        const Status expectedStatus = Status.Resolved;
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.ChangeRiskStatus(Input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testRisk.GetRiskStatus() == expectedStatus);
    }
    
    [Test]
    public void ChangeRiskStatus_OnHold_ReturnsError() {
        
        // Arrange
        const string Input = "OnHold";
        const string expectedString = "That is not a valid status";
        Risk testRisk = new Risk();
        
        // Act
        string result = testRisk.ChangeRiskStatus(Input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
    }
}