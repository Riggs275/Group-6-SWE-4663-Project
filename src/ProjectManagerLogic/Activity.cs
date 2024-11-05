namespace ProjectManagerLogic;

using System;
using System.Collections.Generic;

class ActivityEntry
{
    public string ActivityName { get; set; }
    public DateTime EstimatedTime { get; set; }
    public List<TimeLogEntry> TotalTime { get; set; }

    public ActivityEntry(string activityName, DateTime estimatedTime)
    {
        ActivityName = activityName;
        EstimatedTime = estimatedTime;
        TotalTime = new List<TimeLogEntry>();
    }

    public void AddTimeLog(TimeLogEntry timeLog)
    {
        TotalTime.Add(timeLog);
    }
}

class Activity
{
    private List<ActivityEntry> activities = new List<ActivityEntry>();

    public void AddActivity(ActivityEntry activity)
    {
        activities.Add(activity);
        Console.WriteLine($"Activity added: {activity.ActivityName}");
    }

    public bool RemoveActivity(string activityName)
    {
        var activity = activities.Find(a => a.ActivityName == activityName);
        if (activity != null)
        {
            activities.Remove(activity);
            Console.WriteLine($"Activity removed: {activityName}");
            return true;
        }
        return false;
    }

    public List<ActivityEntry> ListActivities()
    {
        return new List<ActivityEntry>(activities);
    }
}
