namespace ProjectManagerLogic;

using System;
using System.Collections.Generic;

public class Activity {
    
    #region Attributes

        public Task activityType {
            get; 
            private set;
        }

        public TimeSpan estimatedTime {
            get; 
            private set;
        }

        public TimeSpan totalTimeSpent {
            get;
            private set;
        }
        
        private List<TimeLog> loggedTime = new List<TimeLog>();

        public int loggedTimeCount {
            get; 
            private set;
        }
        
        private static int activityID { get; set; }
        private string errorMessage { get; set; }

    #endregion

    #region Constructor

        public Activity() {
            activityID++;
        }

    #endregion
    
    #region Methods
    
        public string ChangeActivityType(string taskType) {
            
            switch (taskType.ToUpper()) { 
                case "REQUIREMENTANALYSIS":
                    activityType = Task.RequirementAnalysis;
                    break;
                
                case "DESIGN":
                    activityType = Task.Design;
                    break;
                
                case "CODING":
                    activityType = Task.Coding;
                    break;
                
                case "TESTING":
                    activityType = Task.Testing;
                    break;
                
                case "MANAGEMENT":
                    activityType = Task.Management;
                    break;
                
                default:
                    errorMessage = "That is not a valid Task!";
                    return errorMessage;
            }
            
            return "Task successfully changed!";
        }
        
        
        public string SetEstimatedTime(int[] TimeValues) {
            
            /* Method should take in 4 ints and assign it accordingly
             index  | TimeSlot
                0      Weeks
                1      Days
                2      Hours
                3      Minutes
            */

            if (TimeValues.Length != 4) {
                errorMessage = "Incorrect amount of numbers taken in!";
                return errorMessage;
            }
            
            TimeSpan updatedETA = new TimeSpan(
                TimeValues[1],
                TimeValues[2], 
                TimeValues[3],
                0);
            

            if (TimeValues[0] > 0) {
                updatedETA = updatedETA.Add(TimeSpan.FromDays(TimeValues[0]));
            }  
            // Adds weeks if applicable


            estimatedTime = updatedETA;
            
            return "Estimated time updated successfully!";
        }
        
        public string LogTime(User Member, int[] TimeLogged) {
            
            // Method works near identically to SetEstimatedTime()

            if (TimeLogged.Length != 4) {
                errorMessage = "Incorrect amount of numbers taken in!";
                return errorMessage;
            }
            
            TimeSpan timeToBeLogged = new TimeSpan(
                TimeLogged[1],
                TimeLogged[2], 
                TimeLogged[3],
                0);
            

            if (TimeLogged[0] > 0) {
                timeToBeLogged = timeToBeLogged.Add(TimeSpan.FromDays(TimeLogged[0] * 7));
            }  
            // Adds weeks if applicable


            loggedTime.Add(new TimeLog(Member, timeToBeLogged));
            loggedTimeCount++;
            
            return "Time logged successfully!";
        }

        public string GetTimeString(TimeSpan allTime) {
            
            if (TimeSpan.Compare(allTime, TimeSpan.Zero) > 0) {
                
                string finalTime = "";

                if (allTime.Days > 7) {
                    finalTime += ((allTime.Days / 7));
                    allTime = allTime.Subtract(TimeSpan.FromDays(7));
                }
                else {
                    finalTime += "0";
                }

                finalTime += "w ";
                // TimeSpan doesn't have a built in week value

                if (allTime.TotalHours >= 24) {
                    finalTime += (allTime.Days);
                }
                else {
                    finalTime += "0";
                }

                finalTime += "d ";

                if ((allTime.TotalMinutes >= 60) && (allTime.Hours != 0)) {
                    finalTime += (allTime.Hours);
                }
                else {
                    finalTime += "0";
                }

                finalTime += "h ";

                if ((allTime.Minutes != 0) && (allTime.TotalSeconds != 0)) {
                    finalTime += (allTime.Minutes);
                }
                else {
                    finalTime += "0";
                }

                finalTime += "m ";

                return ("Total Time: " + finalTime);
            }

            errorMessage = "No time recorded for this.";
            return errorMessage;
        }

        #region Calculation Methods

            public TimeSpan CalculateTotalTimeSpent() {
            
                TimeSpan allTime = new TimeSpan(0, 0, 0);
            
                if (loggedTime.Count > 0) {
                    foreach (TimeLog task in loggedTime) {
                        allTime = allTime.Add(task.timeSpent);
                    }

                    totalTimeSpent = allTime;
                }

                return allTime;
            }

            public TimeSpan CalculateRemainingTime() {

                TimeSpan remainingTime = new TimeSpan(0, 0, 0);
                CalculateTotalTimeSpent();

                if (TimeSpan.Compare(totalTimeSpent, TimeSpan.Zero) != 0) {
                    // If time has been logged at least once
                    
                    if (totalTimeSpent > estimatedTime) {
                        remainingTime = new TimeSpan(0, 0, 1);
                        // 1 second will show no remaining time but not return an error
                    }
                    else {
                        remainingTime = estimatedTime - totalTimeSpent;
                    }
                }

                return remainingTime;
            }

            public TimeSpan CalculateTotalTimeByUser(User Member) {

                TimeSpan allTime = new TimeSpan(0, 0, 0);
                
                if (loggedTime.Count > 0) {
                    foreach (TimeLog task in loggedTime) {
                        if (Member.Equals(task.Member)) {
                            allTime = allTime.Add(task.timeSpent);
                        }
                    }
                }

                return allTime;
            }
        
        #endregion
        

    #endregion
    
    #region Unrequired Methods
        public string GetActivityID() {
            return activityID.ToString("D3");
        }

    #endregion
}
