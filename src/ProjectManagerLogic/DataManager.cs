namespace ProjectManagerLogic;

public class DataManager {
    
    #region Variables

    private readonly char delimiterChar = '|';

    #endregion

    #region Master Lists

    public List<User> userMasterList = new List<User>();
    public List<Project> projectMasterList= new List<Project>();
    public List<Activity> activityMasterList = new List<Activity>(); 
    public List<Requirement> requirementMasterList= new List<Requirement>();
    public List<Risk> riskMasterList= new List<Risk>();

    #endregion
    
    #region Import Methods

    public void ImportUser(string line) {

        string[] data = line.Split(delimiterChar);
        int index = userMasterList.Count;

        if (data.Length == 6) {
            
            userMasterList.Add(new User());

            userMasterList[index].setFirstName(data[1]);
            userMasterList[index].setMiddleInitial(data[2]);
            userMasterList[index].setLastName(data[3]);
            userMasterList[index].SetUsername();
            userMasterList[index].password = data[4];
            userMasterList[index].setRole(data[5]);
        }
                
    }

    public void ImportRisk(string line) {

        string[] data = line.Split(delimiterChar);
        int index = riskMasterList.Count;

        if (data.Length == 4) {
            
            riskMasterList.Add(new Risk());

            riskMasterList[index].setName(data[1]);
            riskMasterList[index].setDescription(data[2]);
            riskMasterList[index].ChangeRiskStatus(data[3]);
        }
    }

    public void ImportRequirement(string line) {
        
        string[] data = line.Split(delimiterChar);
        int index = requirementMasterList.Count;

        if (data.Length == 5) {
            
            requirementMasterList.Add(new Requirement());

            requirementMasterList[index].SetDescription(data[1]);
            requirementMasterList[index].SetReferenceNumber(Convert.ToInt32(data[2]));
            requirementMasterList[index].SetRequirementStatus(data[3]);
            requirementMasterList[index].SetImportance(data[4]);
           
        }
    }

    /*
    public void ImportActivity(string line) {
     
        string[] data = line.Split(delimiterChar);
        int listIndex = activityMasterList.Count;

        if (data.Length >= 6) {
            
            activityMasterList.Add(new Activity());

            activityMasterList[listIndex].ChangeActivityType(data[1]);

            int[] EstTime = {
                Convert.ToInt16(data[2]),   // Estimated Time Weeks
                Convert.ToInt16(data[3]),   // Estimated Time Days
                Convert.ToInt16(data[4]),   // Estimated Time Hours
                Convert.ToInt16(data[5])    // Estimated Time Minutes
            };

            activityMasterList[listIndex].SetEstimatedTime(EstTime);

            int enumerationIndex = Convert.ToInt16(data[6]);
            int activityEnumerator = 6;
            
            for (int i = 0; i <= enumerationIndex; i++) {

                int userIndex = activityEnumerator + 1;

                int[] loggedTime = {
                    Convert.ToInt16(data[activityEnumerator + 2]),   // Weeks
                    Convert.ToInt16(data[activityEnumerator + 3]),   // Days
                    Convert.ToInt16(data[activityEnumerator + 4]),   // Hours
                    Convert.ToInt16(data[activityEnumerator + 5])    // Minutes
                };

                activityMasterList[listIndex].LogTime(GetUser(data[userIndex]), loggedTime);

                activityEnumerator += 5;
            }
        }
    }
    */

    public void ImportProjects(string line) {

        string[] data = line.Split(delimiterChar);
        int listIndex = projectMasterList.Count;

        if (data.Length >= 3) {
            
            projectMasterList.Add(new Project());

            projectMasterList[listIndex].SetDescription(data[1]);
            projectMasterList[listIndex].SetProjectOwner(GetUser(data[2])); // data[2] = Lead username
            
            // data [3] is # of members
            int memberEnumIndex = Convert.ToInt32(data[3]);
            
            for (int i = 0; i <= memberEnumIndex - 1; i++) {

                projectMasterList[listIndex].AddProjectMember(GetUser(data[4 + i]));
                // 4 since i starts at 0
                // data[4 + i] contains member username
            }
            
            // data[4 + memberindex] is # of risks
            int riskEnumIndex = Convert.ToInt16(data[4 + memberEnumIndex]);
            int postIndex = 5 + memberEnumIndex;

            for (int j = 0; j <= riskEnumIndex; j++) {

                int riskEnumerator = j + 5 + memberEnumIndex;
                projectMasterList[listIndex].AddProjectRisk(GetRisk(data[riskEnumerator]));
                postIndex = riskEnumerator;
            }

            projectMasterList[listIndex].AssignDate(true, DateTime.Parse(data[postIndex]));
            projectMasterList[listIndex].AssignDate(false, DateTime.Parse(data[postIndex ]));
            projectMasterList[listIndex].ChangeProjectStatus(data[postIndex + 2]);
            projectMasterList[listIndex].ChangeProjectPriortity(data[postIndex + 3]);

            int functionalReqEnumIndex = Convert.ToInt16(data[postIndex + 4]);
            int x = postIndex;

            for (int k = 0; k <= functionalReqEnumIndex; k+=2) {

                int functionalEnumerator = k + 4 + x;
                // x exists so postIndex doesn't turn into a really high number breaking the array

                if (data[functionalEnumerator + 1].Equals("T")) {
                    projectMasterList[listIndex].AddRequirement(true, 
                        GetRequirement(Convert.ToInt32(data[functionalEnumerator + 2])));
                }
                else {
                    projectMasterList[listIndex].AddRequirement(false, 
                        GetRequirement(Convert.ToInt32(data[functionalEnumerator + 2])));
                }
                
            }
         

        }
        
    }

    public void ImportData(string filePath) {

        using (StreamReader reader = new StreamReader(filePath)) {

            string line;

            while ((line = reader.ReadLine()) != null) {

                switch (line.Substring(0,2)) {
                    
                    case "Pr":
                        ImportProjects(line);
                        break;
                    
                    case "Re":
                        ImportRequirement(line);
                        break;
                    
                    case "Ri":
                        ImportRisk(line);
                        break;
                    
                    case "Us":
                        ImportUser(line);
                        break;
                    
                    default:
                        break;
                }
            }

        }
    }

    #endregion

    #region Export Methods

    public void SaveProjectsToFile(string filePath) {

        using (StreamWriter writer = new StreamWriter(filePath)) {
            foreach (var loggeduser in userMasterList) {
                string userData = ("U|" + $"{loggeduser.firstName}|{loggeduser.middleInitial}|" +
                                   $"{loggeduser.lastName}|{loggeduser.username}|{loggeduser.password}" +
                                   $"{loggeduser.userRole.ToString()}");
                writer.WriteLine(userData);
            }

            foreach (Risk loggedRisk in riskMasterList) {
                string riskData = ("Ri|" + $"{loggedRisk.riskName}|{loggedRisk.Description}" +
                                   $"{loggedRisk.Condition.ToString()}");
                writer.WriteLine(riskData);
            }

            foreach (Requirement loggedReq in requirementMasterList) {
                string requirementData = ("Re|" + $"{loggedReq.description}|" +$"{loggedReq.GetReferenceNumber()}|"+
                                          $"{loggedReq.requirementStatus.ToString()}|" +
                                          $"{loggedReq.importance.ToString()}");
                writer.WriteLine(requirementData);
            }

            foreach (Project proj in projectMasterList) {
                string projectData = ("P|" + $"{proj.Description}|{proj.Lead.username}|" +
                                      $"{proj.Members.Count}|");

                for(int i = 0; i < proj.Members.Count; i++) {
                    projectData += ($"{proj.Members[i].username}|");
                }

                projectData += ($"{proj.Risks.Count}|");

                for (int j = 0; j < proj.Risks.Count; j++) {
                    projectData += ($"{proj.Risks[j].GetRiskCode()}|");
                }

                projectData += ($"{proj.startDate.ToString("MM/dd/yyyy")}|" +
                                $"{proj.endDate.ToString("MM/dd/yyyy")}|" +
                                $"{proj.projectStatus.ToString()}|{proj.projectPriority.ToString()}|");
                projectData += ($"{proj.functionalRequirements.Count+proj.nonfunctionalRequirements.Count}");
                for (int k=0;k<proj.functionalRequirements.Count;k++) { 
                    projectData += ($"|T|{proj.functionalRequirements[k].GetReferenceNumber()}|"); 
                }
                for (int k = 0; k < proj.nonfunctionalRequirements.Count; k++)
                {
                    projectData += ($"|F|{proj.nonfunctionalRequirements[k].GetReferenceNumber()}|");
                }
                writer.WriteLine(projectData);
            }
            
        }

        // Projects saved to file successfully
    }
    

    #endregion

    #region Search Methods

    public User GetUser(string username) {

        foreach (User associate in userMasterList) {

            if (associate.username.ToUpper().Contains(username.ToUpper())) {
                return associate;
            }
        }

        return new User();
    }

    public Risk GetRisk(string riskID) {

        foreach (Risk factor in riskMasterList) {

            if (factor.GetRiskCode().Equals(riskID)) {
                return factor;
            }
        }

        return new Risk();
    }

    public Requirement GetRequirement(int referenceNumber) {

        foreach (Requirement req in requirementMasterList) {

            if (req.GetReferenceNumber()==referenceNumber) {
                return req;
            }
        }

        return new Requirement();
    }

    /*
    public Activity GetActivity(string activityID) {

        foreach (Activity task in activityMasterList) {
            if (task.GetActivityID().Equals(activityID)) {
                return task;
            }
        }

        return new Activity();
    } */

    #endregion

}