namespace ProjectManagerLogic;

using System;
using System.Collections.Generic;

public class User
{
    #region attributes
    public string firstName { get; set; }
    public string middleInitial { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public Role role;
    public string roleDescription { get; set; }
    public string errorMessage { get; set; }

    #endregion

    #region constructors
    public User()
    {
        firstName = string.Empty;
        middleInitial = string.Empty;
        lastName = string.Empty;
        username = string.Empty;
        password = string.Empty;
        role = new Role();
        roleDescription = string.Empty;
        errorMessage = string.Empty;
    }
    public User(string fN, string mI, string lN, Role job)
    {
        firstName = fN;
        middleInitial = mI;
        lastName = lN;
        role = job;
        username = string.Empty;
        password = string.Empty;
        roleDescription = string.Empty;
        errorMessage = string.Empty;
    }


    #endregion

    #region methods
    //sets new firstName middle initial and lastName
    public string setFullName(string fN, string mI, string lN)
    {
        string fullName;
        firstName = fN;
        middleInitial = mI;
        lastName = lN;
        fullName = fN + " " + mI + " " + lN;
        return fullName;
    }
    public string setFirstName(string newFN)
    {
        if (newFN.Length > 50)
        {
            errorMessage = "New first name is too long, max length is 50 characters";
            return errorMessage;
        }

        firstName = newFN;
        return firstName;
    }
    public string setMiddleInitial(string newMI)
    {
        if (newMI.Length > 2)
        {
            errorMessage = "New middle initial is too long, max length is 2 characters";
            return errorMessage;
        }

        middleInitial = newMI;
        return middleInitial;
    }
    public string setLastName(string newLN) 
    {
        if (newLN.Length > 50)
        {
            errorMessage = "New Last name is too long, max length is 50 characters";
            return errorMessage;
        }

        lastName = newLN;
        return lastName;
    }



    /* Potential roles for users
    Lead,           // 0
    Developer,      // 1
    CodeReviewer,   // 2
    Tester,         // 3
    Stakeholder     // 4
     */

    public string setRole(string newRole)
    {
        newRole = newRole.ToUpper();
        switch (newRole)
        {
            case "TESTER":
                role = Role.Tester;
                break;
            case "DEVELOPER":
                role = Role.Developer;
                break;
            case "CODEREVIEWER":
                role = Role.CodeReviewer;
                break;
            case "LEAD":
                role = Role.Lead;
                break;
            case "STAKEHOLDER":
                role = Role.Stakeholder;
                break;
            default:
                errorMessage = "That is not a valid Priority";
                return errorMessage;
        }
        return "Role set Correctly!";
    }

    //sets the current user's role description to a new value
    public string setRoleDescription(string newRoleDescription)
    {
        if (newRoleDescription.Length > 150)
        {
            errorMessage = "New description is too long, can't be more than 150 characters";
            return errorMessage;
        }
        roleDescription = newRoleDescription;
        return roleDescription;
    }



    public string GetFullName()
    {

        string name = "";

        if (string.IsNullOrEmpty(middleInitial))
        {
            name = (firstName + " " + lastName);
        }
        else
        {
            name = (firstName + " " + middleInitial + ". " + lastName);
        }

        return name;
    }
}
#endregion