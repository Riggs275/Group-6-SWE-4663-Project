namespace ProjectManagerLogic;

public enum Status {
    
    #region Project Statuses
    
        NotStarted, // 0
        InProgress, // 1
        OnHold,     // 2
        Completed,  // 3
    
    #endregion
    
    #region Risk Statuses
    
        Active = 7, // 7
        Mitigated,  // 8
        Resolved    // 9
    
    #endregion
}