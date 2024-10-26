namespace ProjectManagerLogic;

public class Risk {
    
    #region Attributes
    
        private string riskName { get; set; }
        private string Description { get; set; }
        private Status Condition { get; set; }
        private string errorMessage { get; set; }
        
    #endregion
    
    #region Required Methods

        public string setDescription(string newDescription) {

            if (newDescription.Length > 350) {
                errorMessage = "Description length cannot exceed 350 characters!";
                return errorMessage;
            }

            Description = newDescription;
            return "Description saved successfully!";
        }
        // PREQ-1.4.2 & 1.4.3

        public string ChangeRiskStatus(string newStatus) {
            
            
            switch (newStatus.ToUpper()) {
                case "ACTIVE":
                    Condition = Status.Active;
                    break;
                
                case "MITIGATED":
                    Condition = Status.Mitigated;
                    break;
                
                case "RESOLVED":
                    Condition = Status.Resolved;
                    break;
                
                default:
                    errorMessage = "That is not a valid status";
                    return errorMessage;
            }
            
            return "Status successfully changed!";
        }
        //PREQ-1.4.4
    
    #endregion
    
    #region Getter Methods

        public string GetName() {
            return riskName;
        }

        public Status GetRiskStatus() {
            return Condition;
        }
    
    #endregion
    
    #region Unrequired (but not unnecessary) Methods

        public string setName(string name) {
            
            if (name.Length > 50) {
                errorMessage = "Risk name cannot exceed 50 characters!";
                return errorMessage;
            }

            riskName = name;
            return "Name saved successfully!";
        }
    
    #endregion
    
    
    
}