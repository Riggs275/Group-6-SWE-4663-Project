namespace ProjectManagerLogic;
public class Requirement {

    #region Attributes

    public string description { get; set; }
    private static int referenceNum { get; set; }
    public Status requirementStatus;
    public Priority importance;
    public User owner;
    private string errorMessage { get; set; }

    #endregion

    #region constructor
    public Requirement() {
        description = string.Empty;
        referenceNum++;
        requirementStatus = new Status();
        importance = Priority.Low;
        owner = new User();
        errorMessage = string.Empty;
    }
    #endregion



    #region methods
    
    public string SetDescription(string newDescription) {
        
        if (newDescription.Length >= 1001) {
            errorMessage = "Description length cannot exceed 1,000 characters!";
            return errorMessage;
        }
        
        description = newDescription;
        return "Description saved successfully!";
    }

    /*
     * potential requirement statuses
     * NotStarted, // 0
        InProgress, // 1
        OnHold,     // 2
        Completed,  // 3
     */
    public string setRequirementStatus(string newStatus) {
        
        switch (newStatus.ToUpper()) {
            case "NOT STARTED":
                requirementStatus = Status.NotStarted;
                break;

            case "IN PROGRESS":
                requirementStatus = Status.InProgress;
                break;
            
            case "ON HOLD":
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
    public string setImportance(string newPriority) {
        
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
}
