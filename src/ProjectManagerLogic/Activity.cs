namespace ProjectManagerLogic;

using System;
using System.Collections.Generic;

class Activity
{
    public string ActivityName { get; set; }
    public DateTime EstimatedTime { get; set; }
    public List<TimeLog> TotalTime { get; set; }

    private List<Activity> activities = new List<Activity>();

    public Activity(string activityName, DateTime estimatedTime)
    {
        ActivityName = activityName;
        EstimatedTime = estimatedTime;
        TotalTime = new List<TimeLog>();
    }

    public void AddTimeLog(TimeLog timeLog)
    {
        TotalTime.Add(timeLog);
    }

    public void AddActivity(Activity activity)
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

    public List<Activity> ListActivities()
    {
        return new List<Activity>(activities);
    }
}
