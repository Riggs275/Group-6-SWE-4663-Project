namespace ProjectManagerLogic;

public class Risk {
    
    #region Attributes
    
        public string riskName { 
            get; 
            private set; 
        }

        public string Description {
            get; 
            private set;
        }
        public Status Condition {
            get; 
            private set;
        }
        
        private static int riskID { get; set; }
        private string errorMessage { get; set; }
        
    #endregion
    
    #region Constructor

    public Risk() {

        riskName = string.Empty;
        Description = string.Empty;
        riskID++;
    }
    
    #endregion
    
    #region Required Methods

        public string setDescription(string newDescription) {

            if (newDescription.Length > 350) {
                errorMessage = "Description length cannot exceed 350 characters!";
                return errorMessage;
            }

            Description = newDescription.Replace('|', '_');
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
    
    #region Unrequired (but not unnecessary) Methods

        public string setName(string name) {
            
            if (name.Length > 50) {
                errorMessage = "Risk name cannot exceed 50 characters!";
                return errorMessage;
            }

            riskName = name.Replace('|', '_');
            return "Name saved successfully!";
        }
        
        public string GetRiskCode() {
            return riskID.ToString("D3");
        }
    
    #endregion
    
    
    
}