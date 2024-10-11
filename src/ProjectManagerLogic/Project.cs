namespace ProjectManagerLogic;

public class Project {

    #region Attributes
    
        private string Description { get; set; }
    
        private User Lead {get; set;}
        private List<User> Members = new List<User>();
        private List<Risk> Risks = new List<Risk>();
    
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }
        
        private Status projectStatus { get; set; }
        
        private Priority projectPriority { get; set; }
    
        private List<Requirement> functionalRequirements = new List<Requirement>();
        private List<Requirement> nonfunctionalRequirements = new List<Requirement>();
    
        private List<Activity> Activities = new List<Activity>();

        private string errorMessage { get; set; }

    #endregion
    
    
    
    #region Helper Methods

        public User FindUserByName(string name) {
            
            // If statement to determine that string is not empty
            // Foreach loop traversing through list of members
            // If found return member
            // Otherwise return new user with errorMessage
            

            return new User();
            // Error User should be considered
        }
        
        // Master list of users should be considered

        public Risk FindRiskByDescription(string descriptor) {

            // Traverse through risk list
            
            return new Risk();
            //Error Risk should be considered
        }

        public Risk FindRiskBySeverity(Priority severity) {

            // Traverse through risk list
            
            return new Risk();
        }
        
    
    #endregion

    
    
    #region Required Methods
    
        public string SetDescription(string input) {

            if (input.Length > 5000) {
                errorMessage = "Error! Description length cannot exceed 5,000 characters!";
            }

            Description = input;
            return "Description saved successfully!";
        }
        // PREQ-1.1
        
        public string SetProjectOwner(User newLead) {
            
            // Helper method Finds user
            
            return "";
         }
         // PREQ-1.2
         
         #region Project Member Methods

            public string AddProjectMember(User Member) {
                
                // Will most likely need to access a master list for this

                return "Member added successfully!";
            }

            public string RemoveProjectMember(User Member) {

                // Find user by name
                
                return "Member removed successfully";
            }
            
         #endregion
         // PREQ-1.3
         
         
         #region Project Risk Methods

            public string AddProjectRisk(string description, Priority riskLevel) {

                return "Risk added successfully";
            }

            public string RemoveProjectRisk(Risk removeeRisk) {

                
                
                return "Risk successfully removed!";
            }
         
         #endregion
         //PREQ-1.4
         
         
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

        public string ChangeProjectStatus(string newStatus) {

            switch (newStatus.ToUpper()) {
                case "NOT STARTED":
                    projectStatus = Status.NotStarted;
                    break;
                
                case "IN PROGRESS":
                    projectStatus = Status.InProgress;
                    break;
                
                case "ON HOLD":
                    projectStatus = Status.OnHold;
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
        
        public string ChangeProjectPriortity(string newPriority) {

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
        //PREQ-1.7
        
        
        
        #region Project Requirement Methods
        
            //Methods TBA
            
        #endregion
        //PREQ-2

        
        
        
        public void GenerateReport(bool effort) {
            
        }
        //PREQ-4.1 & 4.2
        
        #endregion

}