using System;
using System.Diagnostics;

namespace ProjectManagerLogic;

public class Project {

    #region Attributes
    
        private string Description { get; set; }
    
        //private Members Lead {get; set;}
        //private List<Members> Members = new List<Members>();
        //private List<Risk> Risks = new List<Risk>();
    
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        
        private Status projectStatus { get; set; }
        
        private Priority projectPriority { get; set; }
    
        //private List<Requirement> functionalRequirements = new List<Requirement>();
        //private List<Requirement> nonfunctionalRequirements = new List<Requirement>();
    
        //private List<Activity> Activities = new List<Activity>();

        private string errorMessage { get; set; }

    #endregion

    #region PREQ Methods
        public string SetDescription(string input) {

            if (input.Length > 5000) {
                errorMessage = "Error! Description length cannot exceed 5,000 characters!";
            }

            Description = input;
            return "Description saved successfully!";
        }
        // PREQ-1.1
        
        /*public string SetProjectOwner(Member newLead) {
            
            
         }
         // PREQ-1.2
         */

        public string AssignDate(bool start, DateTime anotherDay) {

            if (start) {
                 // If start is true, method works with start date
                 if(DateTime.Compare(anotherDay, endDate) >= 0) {
                     errorMessage = "Start date must be earlier than end date!";
                 }
                 else {
                     startDate = anotherDay;
                 }
            }
            else {
                // If start is false, method works with end date
                if (DateTime.Compare(anotherDay, startDate) <= 0) {
                    errorMessage = "End date must be later than start date!";
                }
                else {
                    endDate = anotherDay;
                }
            }
           
            return "New start date successfully assigned!";
        }
        // PREQ-1.5

        public string changeStatus(string newStatus) {

            switch (newStatus.ToUpper()) {
                case "NOT STARTED":
                    projectStatus = Status.Not_Started;
                    break;
                
                case "IN PROGRESS":
                    projectStatus = Status.In_Progress;
                    break;
                
                case "ON HOLD":
                    projectStatus = Status.On_Hold;
                    break;
                
                case "COMPLETED":
                    projectStatus = Status.Completed;
                    break;
                
                default:
                    errorMessage = "That is not a valid status";
                    return errorMessage;
            }
            
            return "Status successfully changed!";
        }
        //PREQ-1.6
        
        public string changePriortity(string newPriority) {

            switch (newPriority.ToUpper()) {
                case "LOW":
                    projectPriority = Priority.Low;
                    break;
                
                case "MEDIUM":
                    projectPriority = Priority.Medium;
                    break;
                
                case "HIGH":
                    projectPriority = Priority.High;
                    break;
                
                case "CRITICAL":
                    projectPriority = Priority.Critical;
                    break;
                
                default:
                    errorMessage = "That is not a valid priority";
                    return errorMessage;
            }

            return "Priority changed successfully!";
        }

        public void GenerateReport(bool effort) {
            
        }
        //PREQ-4.1 & 4.2
        
        #endregion
        
    #region Selction Methods
    
        /*public Member FindMemberByName(string name) {
            // If statement to determine that string is not empty
            // Implement a foreach loop traversing through members list
            // If found return member
            // Otherwise, errorMessage in member should be populated
         } */
    
    #endregion

}