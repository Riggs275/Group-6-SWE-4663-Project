namespace ProjectLogicUnitTests;

using System;

class ActivityUnitTest
{
    public void RunTests()
    {
        TestAddActivity();
        TestRemoveActivity();
        TestListActivities();
    }

    private void TestAddActivity()
    {
        Activity manager = new Activity("Manager", DateTime.Now);
        Activity process = new Activity("Process", DateTime.Now);

        manager.AddActivity(process);
        var activities = manager.ListActivities();

        Console.WriteLine("TestAddActivity: " +
            (activities.Exists(a => a.ActivityName == "Process") ? "Passed" : "Failed"));
    }

    private void TestRemoveActivity()
    {
        Activity manager = new Activity("Manager", DateTime.Now);
        Activity export = new Activity("Export", DateTime.Now);

        manager.AddActivity(export);
        bool removed = manager.RemoveActivity("Export");
        var activities = manager.ListActivities();

        Console.WriteLine("TestRemoveActivity: " +
            (removed && activities.TrueForAll(a => a.ActivityName != "Export") ? "Passed" : "Failed"));
    }

    private void TestListActivities()
    {
        Activity manager = new Activity("Manager", DateTime.Now);
        Activity save = new Activity("Save", DateTime.Now);

        manager.AddActivity(save);

        var activities = manager.ListActivities();
        Console.WriteLine("TestListActivities: " +
            (activities.Count == 1 && activities[0].ActivityName == "Save" ? "Passed" : "Failed"));
    }
}
