namespace ProjectManagerLogic;

public class User {
    
    #region Attributes
    public string firstName { get; set; }
    public string middleInitial { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string password { get; set; }

    public Role userRole {
        get;
        private set;
    }

    public string roleDescription {
        get; 
        private set;
    }
    
    private static int userIdentifier { get; set; }
    private string errorMessage { get; set; }

    #endregion

    #region Constructors
    public User() {
        firstName = string.Empty;
        middleInitial = string.Empty;
        lastName = string.Empty;
        username = string.Empty;
        password = string.Empty;
        userRole = new Role();
        roleDescription = string.Empty;
        errorMessage = string.Empty;
    }
    public User(string fN, string mI, string lN, Role job) {
        firstName = fN;
        middleInitial = mI;
        lastName = lN;
        userRole = job;
        username = string.Empty;
        password = string.Empty;
        roleDescription = string.Empty;
        errorMessage = string.Empty;
    }


    #endregion

    #region Methods
    
    public string setFirstName(string newFN) {
        
        if (newFN.Length > 50) {
            errorMessage = "New first name is too long, max length is 50 characters";
            return errorMessage;
        }

        firstName = newFN.Replace('|', '_');
        return "User first name set successfully!";
    }
    
    public string setMiddleInitial(string newMI) {
        
        if (newMI.Length > 2) {
            errorMessage = "New middle initial is too long, max length is 2 characters";
            return errorMessage;
        }

        middleInitial = newMI.Replace('|', '_');
        return "User middle initial set successfully!";
    }
    
    public string setLastName(string newLN) {
        
        if (newLN.Length > 50) {
            errorMessage = "New last name is too long, max length is 50 characters";
            return errorMessage;
        }

        lastName = newLN.Replace('|', '_');
        return "User last name set successfully!";
    }



    /* Potential roles for users
    Lead,           // 0
    Developer,      // 1
    CodeReviewer,   // 2
    Tester,         // 3
    Stakeholder     // 4
     */

    public string setRole(string newRole) {
        
        switch (newRole.ToUpper()) {
            case "LEAD":
                userRole = Role.Lead;
                roleDescription = ("Responsible for overseeing the successful execution of project. " +
                                   "Makes high-level decisions, manages resources, and communicates " +
                                   "progress to higher management or clients.");
                break;
            
            case "DEVELOPER":
                userRole = Role.Developer;
                roleDescription = ("Responsible for writing and maintaining code for the project. " +
                                   "Works closely with project manager and other team members to " +
                                   "ensure the project's success. Stays updated with the latest " +
                                   "technologies and best practices to ensure the quality and " +
                                   "efficiency of the project.");
                break;
            
            case "CODEREVIEWER":
                userRole = Role.CodeReviewer;
                roleDescription = ("Reviews the code written by developers to ensure it is of high " +
                                   "quality, adheres to best practices, and meets the project’s " +
                                   "standards.");
                break;
            
            case "TESTER":
                userRole = Role.Tester;
                roleDescription = ("Responsible for ensuring that the project meets all requirements " +
                                   "and functions as intended before it is released.");
                break;
            
            case "STAKEHOLDER":
                userRole = Role.Stakeholder;
                roleDescription = ("Responsible for defining the goals and requirements of the project. " +
                                   "May provide feedback during various phases of development, make " +
                                   "decisions about the direction of the project, and help resolve issues.");
                break;
            
            default:
                errorMessage = "That is not a valid role";
                return errorMessage;
        }
        
        return "Role set successfully!";
    }
    //sets the current user's role description to a new value
    

    public string GetFullName() {
        
        if((firstName.Equals("")) || (lastName.Equals(""))) {
            errorMessage = "First and/or last name isn't set";
            return errorMessage;
        }

        if (string.IsNullOrEmpty(middleInitial)) {
            return (firstName + " " + lastName);
        }

        return (firstName + " " + middleInitial + ". " + lastName);
    }
    
    #endregion
    
    #region Not Stated (but required) Methods

    public void SetUsername() {
        username = (firstName.Substring(0, 1).ToUpper() + 
                    lastName.Substring(0, 1).ToUpper() + 
                    userIdentifier.ToString("D3"));
    }

    #endregion
}
