namespace ProjectManagerLogic;

public class User {

    public string firstName { get; set; }
    public string middleInitial { get; set; }
    public string lastName { get; set; }
    public bool isSuccess { get; set; }
    public string errorMessage { get; set; }


    #region Not required (but helpful) Methods

        public string GetFullName() {

            string name = "";
            
            if (string.IsNullOrEmpty(middleInitial)) {
                name = (firstName + " " + lastName);
            }
            else {
                name = (firstName + " " + middleInitial + ". " + lastName);
            }

            return name;
        }


    #endregion
}