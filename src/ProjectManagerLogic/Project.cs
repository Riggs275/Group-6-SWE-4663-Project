namespace ProjectManagerLogic;

public class Project {

    #region Attributes
    
    private string Description { get; set; }
    
        private User Lead {get; set;}
        private List<User> Members = new List<User>();
        private List<Risk> Risks = new List<Risk>();
    
        private DateTime startDate { get; set; }
        private DateTime endDate { get; set; }

        public Status projectStatus {
            get; 
            private set;
        }

        public Priority projectPriority {
            get; 
            private set;
        }
    
        private List<Requirement> functionalRequirements = new List<Requirement>();
        private List<Requirement> nonfunctionalRequirements = new List<Requirement>();
    
        private List<Activity> Activities = new List<Activity>();
        
        private DateTime totalTimeSpent { get; set; }
        private DateTime totalEstimatedTime { get; set; }

        private string errorMessage { get; set; }

    #endregion
    

    
    #region Required Methods
    
        public string SetDescription(string input) {

            if (input.Length > 5000) {
                errorMessage = "Description length cannot exceed 5,000 characters!";
                return errorMessage;
            }

            Description = input;
            return "Description saved successfully!";
        }
        // PREQ-1.1
        
        public string SetProjectOwner(User newLead) {
            
            Lead = newLead;
            return ("Project owner set to " + Lead.GetFullName() + "!");
         }
         // PREQ-1.2
         
         #region Project Member Methods

            public string AddProjectMember(User Member) {
                
                if (Members.Contains(Member)) {
                    errorMessage = "The member " + Member.GetFullName() + " is already in the risk list";
                    return errorMessage;
                }
                
                Members.Add(Member);
                return (Member.GetFullName() + " has successfully been added as a member!");
            }

            public string RemoveProjectMember(User Member) {

                if (Members.Contains(Member)) {
                    Members.Remove(Member);
                    return (Member.GetFullName() + " has successfully been removed from members!");
                }
                
                
                return (Member.GetFullName() + " is not a member for this project.");
            }

            public string DisplayProjectMembers() {

                string finalList = "";

                if (Members.Count() != 0) {
                    foreach (User teamMember in Members) {
                        finalList += (teamMember.GetFullName() + "\n");
                    }
                }
                else {
                    finalList = "There are no users for the project.";
                }

                return finalList;
            }

            #endregion
         // PREQ-1.3
         
         
         #region Project Risk Methods

            public string AddProjectRisk(Risk AddedRisk) {

                if (Risks.Contains(AddedRisk)) {
                    errorMessage = "The risk " + AddedRisk.riskName + " is already in the risk list";
                    return errorMessage;
                }
                
                Risks.Add(AddedRisk);
                return "Risk added successfully!";
            }

            public string RemoveProjectRisk(Risk removeeRisk) {

                if (Risks.Contains(removeeRisk)) {
                    Risks.Remove(removeeRisk);
                    return "Risk successfully removed!";
                }

                errorMessage = ("The risk " + removeeRisk.riskName + " is not in the risk list.");
                return errorMessage;
            }

            public string DisplayRisksByCondition() {
                
                if (Risks.Count() <= 0) {
                    errorMessage = "There are no risks in the risk list.";
                    return errorMessage;
                }

                string finalList = "";
                string[] riskStatuses = { "Active", "Mitigated", "Resolved" };

                for (int i = 0; i < 3; i++) {
                    
                    finalList += (riskStatuses[i] + ":\n\n");
                    
                    foreach (Risk threat in Risks) {
                        
                        if ((int)threat.Condition == (i + 7)) {
                            finalList += (threat.riskName + "\n");
                        }
                        
                    }

                    finalList += "\n\n";
                }

                return finalList;
            }

            #endregion
         //PREQ-1.4
         
         
        public string AssignDate(bool start, DateTime anotherDay) {

            if (start) {
                 // If start is true, method works with start date
                 if(DateTime.Compare(anotherDay, endDate) >= 0) {
                     errorMessage = "Start date must be earlier than end date!";
                     return errorMessage;
                 }
                 
                 startDate = anotherDay;
                 return "New start date successfully assigned!";
            }
            else {
                // If start is false, method works with end date
                if (DateTime.Compare(anotherDay, startDate) <= 0) {
                    errorMessage = "End date must be later than start date!";
                    return errorMessage;
                }
                
                endDate = anotherDay;
                return "New end date successfully assigned!";
            }
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
        // PREQ-1.6
        
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
        // PREQ-1.7
        
        
        
        #region Project Requirement Methods

            public string AddRequirement(bool functional, Requirement addeeRequirement) {

                if (functional) {
                    if (functionalRequirements.Contains(addeeRequirement)) {
                        errorMessage = "This requirement is already in the functional requirements list";
                        return errorMessage;
                    }
                    
                    functionalRequirements.Add(addeeRequirement);
                }
                else {
                    if (nonfunctionalRequirements.Contains(addeeRequirement)) {
                        errorMessage = "This requirement is already in the nonfunctional requirements list";
                        return errorMessage;
                    }
                    
                    nonfunctionalRequirements.Add(addeeRequirement);
                }

                return "Requirement successfully added!";
            }
            // PREQ-2.1 and 2.2
                
        #endregion
        //PREQ-2
        
        
        public void GenerateReport(bool effort) {
            
        }
        //PREQ-4.1 & 4.2
        
        #endregion

}