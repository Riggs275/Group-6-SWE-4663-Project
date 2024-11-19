namespace ProjectManagerLogic;
public class Requirement
{


    #region attributes
    public string description { get; set; }
    public static int referenceNum { get; set; }
    public Status requirementStatus;
    public Priority importance;
    public User owner;
    public string errorMessage { get; set; }

    #endregion

    #region constructor
    public Requirement()
    {
        description = string.Empty;
        referenceNum++;
        requirementStatus = new Status();
        importance = Priority.Low;
        owner = new User();
        errorMessage = string.Empty;
    }
    #endregion



    #region methods
    public Requirement(string desc, Priority severity, User creator)
    {
        description = desc;
        referenceNum = referenceNum++;
        importance = severity;
        owner = creator;
        requirementStatus = Status.NotStarted;
        errorMessage = "";
    }

    public string SetDescription(string newDescription)
    {
        if (newDescription.Length >= 1001)
        {
            errorMessage = "Description being set is too long";
            return errorMessage;
        }
        description = newDescription;
        return description;
    }

    /*
     * potential requirement statuses
     * NotStarted, // 0
        InProgress, // 1
        OnHold,     // 2
        Completed,  // 3
     */
    public string setRequirementStatus(string newStatus)
    {
        newStatus=newStatus.ToUpper();
        switch (newStatus)
        {
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
    public string setImportance(string newPriority)
    {
        newPriority = newPriority.ToUpper();
        switch (newPriority)
        {
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
