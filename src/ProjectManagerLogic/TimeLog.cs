namespace ProjectManagerLogic;

using System;

public class TimeLog {
    
    #region Attributes

        public User Member {
            get; 
            private set;
        }

        public TimeSpan timeSpent {
            get; 
            private set;
        }
    
    #endregion

    #region Constructor

        public TimeLog(User timeLogger, TimeSpan timeLogged) {

            Member = timeLogger;
            timeSpent = timeLogged;
            
        }
        
    #endregion
    
}
