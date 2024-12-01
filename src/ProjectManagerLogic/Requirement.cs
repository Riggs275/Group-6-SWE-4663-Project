namespace ProjectManagerLogic;
public class Requirement {

    #region Attributes

    public string description {
        get; 
        private set;
    }

    private static int referenceNum { get; set; }

    public Status requirementStatus {
        get;
        private set;
    }

    public Priority importance {
        get;
        private set;
    }
    
    private string errorMessage { get; set; }

    #endregion

    #region constructor
    public Requirement() {
        description = string.Empty;
        referenceNum++;
        requirementStatus = new Status();
        importance = Priority.Low;
        errorMessage = string.Empty;
    }
    #endregion
    
    #region methods
    
    public string SetDescription(string newDescription) {
        
        if (newDescription.Length >= 1001) {
            errorMessage = "Description length cannot exceed 1,000 characters!";
            return errorMessage;
        }
        
        description = newDescription.Replace('|', '_');
        return "Description saved successfully!";
    }

    /*
     * potential requirement statuses
     * NotStarted, // 0
        InProgress, // 1
        OnHold,     // 2
        Completed,  // 3
     */
    public string SetRequirementStatus(string newStatus) {
        
        switch (newStatus.ToUpper()) {
            case "NOTSTARTED":
                requirementStatus = Status.NotStarted;
                break;

            case "INPROGRESS":
                requirementStatus = Status.InProgress;
                break;
            
            case "ONHOLD":
                requirementStatus = Status.OnHold;
                break;
            
            case "COMPLETED":
                requirementStatus = Status.Completed;
                break;
            
            default:
                errorMessage = "That is not a valid status";
                return errorMessage;
        }
        
        return "Status successfully changed!";
    }
    
    /*
     * potential importance statuses
         Critical,   // 0
         High,       // 1
         Medium,     // 2
         Low         // 3
     */
    public string SetImportance(string newPriority) {
        
        switch (newPriority.ToUpper()) {
            case "CRITICAL":
                importance = Priority.Critical;
                break;

            case "HIGH":
                importance = Priority.High;
                break;
            
            case "MEDIUM":
                importance = Priority.Medium;
                break;
            
            case "LOW":
                importance = Priority.Low;
                break;
            
            default:
                errorMessage = "That is not a valid Priority";
                return errorMessage;
        }
        
        return "Priority successfully changed!";
    }
    #endregion
    
    #region That Region for Extra Methods that are needed

    // I am very tired

    public string GetReferenceNumber() {
        return referenceNum.ToString("D3");
    }

    #endregion
}
