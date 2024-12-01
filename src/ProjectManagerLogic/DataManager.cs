namespace ProjectManagerLogic;

public class DataManager {
    
    #region Variables

    private readonly char delimiterChar = '|';

    #endregion

    #region Master Lists

    public List<User> userMasterList;
    public List<Project> projectMasterList;
    public List<Activity> activityMasterList;
    public List<Requirement> requirementMasterList;
    public List<Risk> riskMasterList;

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

        if (data.Length == 4) {
            
            requirementMasterList.Add(new Requirement());

            requirementMasterList[index].SetDescription(data[1]);
            requirementMasterList[index].SetRequirementStatus(data[2]);
            requirementMasterList[index].SetImportance(data[3]);
            // Reference Number will be set on declaration
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
            
            for (int i = 0; i <= memberEnumIndex; i++) {

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
                postIndex = riskEnumerator + 1;
            }

            projectMasterList[listIndex].AssignDate(true, DateTime.Parse(data[postIndex]));
            projectMasterList[listIndex].AssignDate(false, DateTime.Parse(data[postIndex + 1]));
            projectMasterList[listIndex].ChangeProjectStatus(data[postIndex + 2]);
            projectMasterList[listIndex].ChangeProjectPriortity(data[postIndex + 3]);

            /*
            int functionalReqEnumIndex = Convert.ToInt16(data[postIndex + 4]);
            int x = postIndex;

            for (int k = 0; k <= functionalReqEnumIndex; k++) {

                int functionalEnumerator = k + 5 + x;
                // x exists so postIndex doesn't turn into a really high number breaking the array

                if (data[functionalEnumerator + 1].Equals("T")) {
                    projectMasterList[listIndex].AddRequirement(true, 
                        GetRequirement(data[functionalEnumerator + 2]));
                }
                else {
                    projectMasterList[listIndex].AddRequirement(false, 
                        GetRequirement(data[functionalEnumerator + 2]));
                }
                
            }
            */

        }
        
    }

    public void ImportData(string filePath) {

        using (StreamReader reader = new StreamReader(filePath)) {

            string line;

            while ((line = reader.ReadLine()) != null) {

                switch (line.Substring(0, 1)) {
                    
                    case "P":
                        ImportProjects(line);
                        break;
                    
                    case "Re":
                        ImportRequirement(line);
                        break;
                    
                    case "Ri":
                        ImportRisk(line);
                        break;
                    
                    case "U":
                        ImportUser(line);
                        break;
                }
            }

        }
    }

    #endregion

    #region Export Methods

    public void SaveProjectsToFile(string filePath) {

        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory)) {
            Directory.CreateDirectory(directory);
        }

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
                string requirementData = ("Re|" + $"{loggedReq.description}|" +
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
                                $"{proj.projectStatus.ToString()}|{proj.projectPriority.ToString()}");
                
                writer.WriteLine(projectData);
            }
            
        }

        // Projects saved to file successfully
    }
    

    #endregion

    #region Search Methods

    public User GetUser(string username) {

        foreach (User associate in userMasterList) {

            if (associate.username.ToUpper().Equals(username.ToUpper())) {
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

    public Requirement GetRequirement(string referenceNumber) {

        foreach (Requirement req in requirementMasterList) {

            if (req.GetReferenceNumber().Equals(referenceNumber)) {
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