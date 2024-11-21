namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class ActivityUnitTest {
    
    [Test]
    public void ChangeActivityType_requirementANALYSIS_ReturnsSuccess() {
        
        // Arrange
        const string input = "requirement ANALYSIS";
        const string expectedString = "Task successfully changed!";
        const Task expectedTask = Task.RequirementAnalysis;
        Activity testActivity = new Activity();
        
        // Act
        string result = testActivity.ChangeActivityType(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testActivity.activityType == expectedTask);
    }
    
    [Test]
    public void ChangeActivityType_Design_ReturnsSuccess() {
        
        // Arrange
        const string input = "Design";
        const string expectedString = "Task successfully changed!";
        const Task expectedTask = Task.Design;
        Activity testActivity = new Activity();
        
        // Act
        string result = testActivity.ChangeActivityType(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testActivity.activityType == expectedTask);
    }
    
    [Test]
    public void ChangeActivityType_CODING_ReturnsSuccess() {
        
        // Arrange
        const string input = "CODING";
        const string expectedString = "Task successfully changed!";
        const Task expectedTask = Task.Coding;
        Activity testActivity = new Activity();
        
        // Act
        string result = testActivity.ChangeActivityType(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testActivity.activityType == expectedTask);
    }
    
    [Test]
    public void ChangeActivityType_testing_ReturnsSuccess() {
        
        // Arrange
        const string input = "testing";
        const string expectedString = "Task successfully changed!";
        const Task expectedTask = Task.Testing;
        Activity testActivity = new Activity();
        
        // Act
        string result = testActivity.ChangeActivityType(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testActivity.activityType == expectedTask);
    }
    
    [Test]
    public void ChangeActivityType_manAGEmenT_ReturnsSuccess() {
        
        // Arrange
        const string input = "manAGEmenT";
        const string expectedString = "Task successfully changed!";
        const Task expectedTask = Task.Management;
        Activity testActivity = new Activity();
        
        // Act
        string result = testActivity.ChangeActivityType(input);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(testActivity.activityType == expectedTask);
    }
    
    [Test]
    public void ChangeActivityType_Gaming_ReturnsSuccess() {
        
        // Arrange
        const string input = "Gaming";
        const string expected = "That is not a valid Task!";
        Activity testActivity = new Activity();
        
        // Act
        string result = testActivity.ChangeActivityType(input);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetEstimatedTime_ValidArray_ReturnsSuccess() {
        
        // Arrange
        const string expectedString = "Estimated time updated successfully!";
        TimeSpan expectedTime = new TimeSpan(10, 6, 4, 0);
        Activity testActivity = new Activity();
        int[] testNumbers = [7, 3, 6, 4];
        
        // Act
        string result = testActivity.SetEstimatedTime(testNumbers);
        
        // Assert
        Assert.That(result.Equals(expectedString));
        Assert.That(TimeSpan.Compare(expectedTime, testActivity.estimatedTime) == 0);
    }

    [Test]
    public void SetEstimateTime_InvalidArray_ReturnsError() {
        
        // Arrange
        const string expected = "Incorrect amount of numbers taken in!";
        Activity testActivity = new Activity();
        int[] testNumbers = [ 1, 2, 3, 4, 5 ];
        
        // Act
        string result = testActivity.SetEstimatedTime(testNumbers);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void LogTime_ValidArrayAndMember_ReturnsSuccess() {
        
        // Arrange
        const string expectedString = "Time logged successfully!";
        Activity testActivity = new Activity();
        User testUser = new User();
        int[] testNumbers = [0, 3, 0, 5];
        
        // Act
        string result = testActivity.LogTime(testUser, testNumbers);
        
        // Assert
        Assert.That(result.Equals(expectedString));
    }

    [Test]
    public void LogTime_InvalidArrayAndValidMember_ReturnsError() {
        
        // Arrange
        const string expected = "Incorrect amount of numbers taken in!";
        Activity testActivity = new Activity();
        User testUser = new User();
        int[] testNumbers = [5, 3, 1, 2, 4, 6];
        
        // Act
        string result = testActivity.LogTime(testUser, testNumbers);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void GetTimeString_ValidTimeSpan_ReturnsSuccess() {
        
        // Arrange
        const string expected = "Total Time: 1w 2d 1h 5m ";
        Activity testActivity = new Activity();
        TimeSpan testTime = new TimeSpan(9, 1, 5, 0);
        
        // Act
        string result = testActivity.GetTimeString(testTime);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void GetTimeString_InvalidTimeSpan_ReturnsError() {
        
        // Arrange
        const string expected = "No time recorded for this.";
        Activity testActivity = new Activity();
        TimeSpan testTime = new TimeSpan(-1, 2, -8, 0);
        
        // Act
        string result = testActivity.GetTimeString(testTime);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void CalculateTotalTimeSpent_TimeList_ReturnsSum() {
        
        // Arrange
        TimeSpan expected = new TimeSpan(5, 2, 30, 0);
        Activity testActivity = new Activity();

        User testUser = new User();
        testActivity.LogTime(testUser, [0, 0, 0, 30]);
        testActivity.LogTime(testUser, [0, 0, 25, 0]);
        testActivity.LogTime(testUser, [0, 4, 1, 0]);
        
        // Act
        TimeSpan result = testActivity.CalculateTotalTimeSpent();
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void CalculateTotalTimeSpent_NoLoggedTimes_ReturnsZero() {
        
        // Arrange
        TimeSpan expected = TimeSpan.Zero;
        Activity testActivity = new Activity();
        
        // Act
        TimeSpan result = testActivity.CalculateTotalTimeSpent();
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void CalculateRemainingTime_SmallerTimeLogAndLargerEstimatedTime_ReturnsDifference() {
        
        // Arrange
        TimeSpan expected = new TimeSpan(1, 1, 0, 0);
        Activity testActivity = new Activity();
        testActivity.SetEstimatedTime([0, 3, 0, 0]);

        User testUser = new User();
        testActivity.LogTime(testUser, [0, 1, 23, 0]);
        
        
        // Act
        TimeSpan result = testActivity.CalculateRemainingTime();
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void CalculateRemainingTime_LargerTimeLogAndSmallerEstimatedTime_ReturnsOneSecond() {
        
        // Arrange
        TimeSpan expected = new TimeSpan(0, 0, 0, 1);
        Activity testActivity = new Activity();
        testActivity.SetEstimatedTime([0, 4, 0, 0]);

        User testUser = new User();
        testActivity.LogTime(testUser, [1, 0, 0, 0]);
        
        // Act
        TimeSpan result = testActivity.CalculateRemainingTime();
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void CalculateRemainingTime_NoLoggedTimeAndEstimatedTime_ReturnsZero() {
        
        // Arrange
        TimeSpan expected = new TimeSpan(0, 0, 0, 0);
        Activity testActivity = new Activity();
        testActivity.SetEstimatedTime([0, 0, 6, 0]);
        
        // Act
        TimeSpan result = testActivity.CalculateRemainingTime();
        
        // Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void CalculateTotalTimeByUser_TimeLoggedByMember_ReturnsSum() {
        
        // Arrange
        TimeSpan expected = new TimeSpan(0, 2, 36, 0);
        Activity testActivity = new Activity();

        User testUserA = new User();
        User testUserB = new User();
        testActivity.LogTime(testUserA, [0, 0, 0, 30]);
        testActivity.LogTime(testUserA, [0, 0, 2, 0]);
        testActivity.LogTime(testUserB, [1, 0, 0, 0]);
        testActivity.LogTime(testUserA, [0, 0, 0, 6]);
        
        // Act
        TimeSpan result = testActivity.CalculateTotalTimeByUser(testUserA);
        
        // Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void CalculateTotalTimeByUser_NoLoggedTimes_ReturnsZero() {
        
        // Arrange
        TimeSpan expected = new TimeSpan(0, 0, 0, 0);
        Activity testActivity = new Activity();

        User testUserA = new User();
        User testUserB = new User();
        testActivity.LogTime(testUserB, [0, 0, 13, 43]);
        
        // Act
        TimeSpan result = testActivity.CalculateTotalTimeByUser(testUserA);
        
        // Assert
        Assert.That(result.Equals(expected));
    }
}
