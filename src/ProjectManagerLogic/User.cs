namespace ProjectManagerLogic;

using System;
using System.Collections.Generic;

public class User
{
    public string firstName { get; set; }
    public string middleInitial { get; set; }
    public string lastName { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public Role role;
    public string roleDescription { get; set; }
    public string errorMessage { get; set; }



    public User()
    {

    }
    //constructor
    public User(string fN, string mI, string lN, Role job)
    {
        firstName = fN;
        middleInitial = mI;
        lastName = lN;
        role = job;
    }

    //sets new firstName middle initial and lastName
    public string setName(string fN, string mI, string lN)
    {
        string fullName;
        firstName = fN;
        middleInitial = mI;
        lastName = lN;
        fullName = fN + " " + mI + " " + lN;
        return fullName;
    }

    public void login(string username, string password)
    {
        //compare username with password in database and alter a variable to being logged in state
    }
    public void logout()
    {
        //sets current state to being a logged out state
    }


    //sets the current user's role description to a new value
    public string setRoleDescription(string newRoleDescription)
    {
        roleDescription = newRoleDescription;
        return roleDescription;
    }


    public List<User> getAllUsers()
    {
        List<User> listOfUsers = new List<User>();
        //line connecting to database to run through and grab all of the users should be in a different area than in user class
        return listOfUsers;
    }

    public User getUser(string username)
    {
        User foundUser = new User();
        //line connecting to database to run through and search for a user based on the input username, should also be in the database connecting class
        return foundUser;
    }
}