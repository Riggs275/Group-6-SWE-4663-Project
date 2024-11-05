namespace ProjectLogicUnitTests;

using System;

class TimeLogUnitTest
{
    public void RunTests()
    {
        TestAddTimeLog();
        TestRemoveTimeLog();
        TestListTimeLogs();
    }

    private void TestAddTimeLog()
    {
        Activity activity = new Activity("Reading", DateTime.Now);
        activity.AddTimeLog(new TimeLog("User1", DateTime.Now));

        var timeLogs = activity.TotalTime;

        Console.WriteLine("TestAddTimeLog: " +
            (timeLogs.Exists(tl => tl.User == "User1") ? "Passed" : "Failed"));
    }

    private void TestRemoveTimeLog()
    {
        Activity activity = new Activity("Coding", DateTime.Now);
        TimeLog manager = new TimeLog("User2", DateTime.Now);

        manager.AddTimeLog(activity, DateTime.Now, "User2");
        bool removed = manager.RemoveTimeLog(activity, "User2");
        var timeLogs = activity.TotalTime;

        Console.WriteLine("TestRemoveTimeLog: " +
            (removed && timeLogs.TrueForAll(tl => tl.User != "User2") ? "Passed" : "Failed"));
    }

    private void TestListTimeLogs()
    {
        Activity activity = new Activity("Gardening", DateTime.Now);
        activity.AddTimeLog(new TimeLog("User3", DateTime.Now));

        var timeLogs = activity.TotalTime;

        Console.WriteLine("TestListTimeLogs: " +
            (timeLogs.Count == 1 && timeLogs[0].User == "User3" ? "Passed" : "Failed"));
    }
}
