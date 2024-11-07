namespace ProjectManagerLogic;


using System;
using System.Collections.Generic;


public class Requirement
{

    public string description {  get; set; }
    public static int referenceNum { get; set; }
    public Status requirementStatus;
    public Priority importance;
    public User owner;
    public string errorMessage { get; set; }

    public Requirement(string desc, Priority severity, User creator)
    {
        description = desc;
        referenceNum = referenceNum++;
        importance = severity;
        owner = owner;
        requirementStatus = Status.NotStarted;
        errorMessage = "";
    }

    public string SetDescription(string newDescription)
    {
        description = newDescription;
        return description;
    }
}