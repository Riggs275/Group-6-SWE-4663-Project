namespace ProjectManagerLogic;
public class Requirement
{

    public string description { get; set; }
    public static int referenceNum { get; set; }
    public Status requirementStatus;
    public Priority importance;
    public User owner;
    public string errorMessage { get; set; }

    public Requirement()
    {
        description = string.Empty;
        referenceNum++;
        requirementStatus = new Status();
        importance = Priority.Low;
        owner = new User();
        errorMessage = string.Empty;
    }
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
        description = newDescription;
        return description;
    }
}