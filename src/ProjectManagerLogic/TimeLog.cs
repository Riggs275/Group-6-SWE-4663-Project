namespace ProjectManagerLogic;

using System;
using System.Collections.Generic;

class TimeLog
{
    public string User { get; private set; }
    public DateTime TimeSpent { get; private set; }
    public string ErrorMessage { get; private set; }

    private List<TimeLog> timeLogs = new List<TimeLog>();

    public TimeLog(string user, DateTime timeSpent, string errorMessage = "")
    {
        User = user;
        TimeSpent = timeSpent;
        ErrorMessage = errorMessage;
    }

    public void AddTimeLog(Activity activity, DateTime timeSpent, string user, string errorMessage = "")
    {
        var entry = new TimeLog(user, timeSpent, errorMessage);
        timeLogs.Add(entry);
        activity.AddTimeLog(entry);
        Console.WriteLine($"Time logged for {activity.ActivityName} by {user}: {timeSpent}. Error: {errorMessage}");
    }

    public bool RemoveTimeLog(Activity activity, string user)
    {
        var timeLog = timeLogs.Find(tl => tl.User == user && activity.TotalTime.Contains(tl));
        if (timeLog != null)
        {
            timeLogs.Remove(timeLog);
            activity.TotalTime.Remove(timeLog);
            Console.WriteLine($"Time log removed for user: {user}");
            return true;
        }
        return false;
    }

    public List<TimeLog> ListTimeLogs()
    {
        return new List<TimeLog>(timeLogs);
    }
}
