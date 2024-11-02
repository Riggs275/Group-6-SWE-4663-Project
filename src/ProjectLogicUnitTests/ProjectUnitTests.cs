namespace ProjectLogicUnitTests;
using ProjectManagerLogic;

public class ProjectUnitTests {

    [Test]
    public void SetDescription_ProperValueDescription_ReturnsSuccess() {
        
        //Arrange
        const string description = "";
        const string expected = "Description saved successfully!";
        Project testProject = new Project();
        
        //Act
        string result = testProject.SetDescription(description);
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetDescription_ExceededCharacterLimitDescription_ReturnsError() {
        
        //Arrange
        const string description = ("9quXXnkFcN2jupWbme7DbxLYFjrFKWC6n2TJSjt0d9Eg176KmLx78BtgBf5pFejeQdV0AFnFqYU17" + 
                                    "YJQZ6QuGVqCR4prUtP9gc2Eg12a1rUmDhVnmjv42P9b8JKfbrRTWiggVtvRv4aqKxMBU7Uev94DKW" +
                                    "LAmqVp46ZB66P8zFaxY3MafKz4dSXt6jmHLXLtymtRPRN065fVYCUb1dCScXS2dQQmEJtM2zamZPM" +
                                    "dkTwfwvkrME9JZUAicu2NytKTXKq3r08m18U5rQyV6Gv6kAjpRE7PPGhEMBPmcizMBbfu4XfnWbHi" +
                                    "tHRCuY9PXt0U6dtgpMgMeAuf7yLhbdu4EiWSQ9FkSH0Zw6rkZeu8D9t2tJn0GpCm6uuw9dJRxj0id" +
                                    "NyGMrkvRdKuEWmGmEH6vVPfnd7TagtpYTX9HwhfTL3MTWYpSrYrJkU1130dX6YurZfDvT1xpPiSyF" +
                                    "93jFMjGhjJHMuzmSPfBk1pSdWv64vkEZSMhjHqjRpDRm9HWbQugeDETdaGALcG3Dxqyxxy30KGzaQ" +
                                    "ueaYfq1JEJw96M804fMRZevTwJHi06RVprpLQL29RhZLdtSTBU9iVkRa4EPa7xN8ZY86ZytDahGYk" +
                                    "nTuF5Yt8RKq8nhBPdRyeRPvik6FRyVDKXWJYa3Xi4YHbbVREnmdSZ7MP8aBjWtjrT2viz0xg1693c" +
                                    "3uPg0UAEyGEUS14aeXKK4T4ypQ9MykXq26LJkBBV1h7tNDcbi998DqBix3ygPY2wRwRMPCXEB3wdv" +
                                    "nYxcLVPKUGxPTLjB4QRJrbx8dwiUP1pLKV59NU219LCWcAczD03D5gVa83i1G8Wv726uv9RWHJjxC" +
                                    "ir1j9uFLjD7Pbym5YhQr85YR3CzeLdxkmw4zmWfxiFSTDWhU2dx01a0G5wb87cBZnBDYL0jC6HrJQ" +
                                    "Qz35MyxV4cn0G7mw47WwZCE3xLF4Lg0iaJPJbDLKWLUFT9A6zm4RfpYtGSw6ENhjXiD8fCy4bwRgD" +
                                    "9LEc0p540CF5DA7q18R4evhYZARTEfW8TErjFuU3DjNHVvNndhqZTNShizErQcGaYbfrSWAvQtHF2" +
                                    "qMGzUfdyk1bPbNvmKewvUHvdpVu1jPiU1S3v3EDQtjGQSP7E35wpaC5iYY4PiDN5kT2HyVexq8qBY" +
                                    "6LMxbeTeX75SxcMRr7EQ8Gg7AXT4Pi7hvq8uUbkSEjKrUzn0v4iRaVJ5Nv4kvFhAzzBtxnnYFZ5v9" +
                                    "QTtQwmyy0TW8aX0uDcJjSmwTAtYAuxPDvkhg9xBQqpDNGC1fkn37Va5LJ2zj06HyycZF0zcUWMNwX" +
                                    "nkXtnWxMS5uSXPE9ru6XCFu38qKkbFXqPcEvbukq2MekezjQn8Z1BjYe4SHQUPuxCJzFRn1t8xFbc" +
                                    "v4NKCXAfLWrhHW5gzY1RnnvkEUtt7fUw60p1Cg3GwHM4eCb0tudubpGYR2UjJkGn5FdTvA2M0C0pB" +
                                    "hvuBWDLLZG4r8LxjrPf5Pt6kvQiY0XpRZw2TjfFXecr3dk4VvEQ6tRipewqtid5V33PMtymG7B7z5" +
                                    "SKeaJLvy3BBC7kBNd8XnMjwZGKxifb5ZPEhzE2y4ETMuMQ0qFxL0TXLgBW79q1Zt6B3zna9PvAYrv" +
                                    "ZaTmuMEEE784U8ndd6V1tGTVg8KJnPkUkMMDHFJG6TCB26a8i22VfS5hMTtETfJ40S197WMLT085L" +
                                    "46vd76mgdmb0BmGLN7C09PxKZu3ZpQ0yNzJnFVGijZxVFNESK47cczgB4vGCWwGVSWi4DfbvfVVze" +
                                    "KFiMyuEi8507EnwAxBmGQ4AVJ3KwMpDcraXUyva6KaRw6JnRueetJbSp9zCgNjnwy5MtG32qWXyRZ" +
                                    "iv829GCi16G1gQBLJBp1g7uuRAGQfrv3DDh6twdQ514ant6t5UvuJ0YXVkg8S9HQiXKRX6VR0V3A8" +
                                    "6iYK3Ej0p7afVxhBRHPrM0nVxGCDZyE2U0zM8748MRhDYDQxz7YTNkJKA8DSLLPbTLQEtujhuhPW9" +
                                    "xgVmcYude8B6kXFmzHuJa5g7j4uzHDtv9YNC2EGZ5KivjGEUZB8mdJdYqYEKeBM3ZXhigN9gYq118" +
                                    "r9unkzY5C8dCePVha6U1HmUkEppuB8ptcRp1rYThZ3t0hd1WWd98k6XXezURgUAid4n1NADEKvMPP" +
                                    "Tb1wGwzCeBjVHwufcPu3zAMJxLScK2wehmQzFJvZbiayCQuY66icZEVngubw3H2jvcqj9eHum4VjZ" +
                                    "ZwvN3XnvKGEdb8XTPkCSYBv3ArSQiqmPaJdZffmc4153BwzFfGDqUz7Cy70FZtTiaieDDPn27hgXw" +
                                    "4h8rpda662XkkNhhcP8MdSGLWdF53aCyzfXQQii71wYYjQnxmhAFSA8tTCwQ2drz2AxzkzDGDfS45" +
                                    "WAbZFqTeMgWqYvmMEKh6FryL37SZdtYDJctZ4UU7VjGrpbFKXExtB3YAd9uffcKTLuZfDGT9SgLEu" +
                                    "qByuJHwA6RVaBPphYzK7YpNGMGXUP6Hjr2gdMEtN4vLbWSmng0uvgRxFb76hdD1Etr8HmyR4cTSea" +
                                    "8cMCzCU3aG3e5gLSYmfKSvAUdvmU4wBaaY2NmupPRgygrdAuyB0e2CEFF4jd0xSc7wGi9PGB7iEwy" +
                                    "fmBTpwBBqr9ZzRywkZ1kwSA3D340k1wrM3Gwiwme2mPbZjnAVHEpyXr4XFPLBS4d7hbDK9yt7Gu04" +
                                    "PpGJbmirjG1paCwRjEGXXcpKZ9hG3zdmjJ9PEUpAHhMwve5Xiz3xCS9wt609FgRDL90n0gpvm6rDS" +
                                    "GqNdM9njgX1Ud0xUMXqC4SBgHj0dBywCCGZ5d6qeJ1GZR55Ni5QEMVqH6QJrV1RCdNrwMtjPaWfDF" +
                                    "TgizkryhBrqLGNFAi0hZLBXJVSbfWVA0tm3cbxLKtX3H9hHrLLkqj6XxGvkDrymiCdXM7qcjbGax3" +
                                    "hp2Bu7pH3NFF57d8m0eSdkxFaHvip5CmE2hSahLy4cv1A0G8cKZBnDNT3czE9HHTeSQP8fPzcLQtT" +
                                    "gDfGnSvE0nmtB9tQ1RzrnE5cQUBEDbXnidwnzhygwCZphyXmFrSiibFt75qSmxtxWRMi5mQJwzKG0" +
                                    "Rr3gXiadypjFdTiHeeyR2489LKVb0Gz3KGDzGHDmLH6iX0aS8xRkYkLrjGaya9HDbgLKapHw8VX6P" +
                                    "CFj8x3WpR7M0S7Mw9HHhWfP3dDQLU8x23gZZnKpkcU9vW6C2aJjZ8dBJ7De3FeZiJbr40WbbZeCg2" +
                                    "MhR0FBqmF0qvKAyRZFD2Waf4VQqn3krtNBAkFRUnwWiiMfvVyhpZ4xbR1kCZuxPQyV2VjmGe4VVtK" +
                                    "nzcqF0aPXFfTjpF9PP9AXWGWHvExUu0fMvrUFMrpR3z6884haaVSEYJFkDNr57y1A8CNvPMuqDD4q" +
                                    "a1S6vmxAn5HJFDWNzK5mYGJM61SqPBcZrUED8JQ6xrDDgXvZ8A0Jcgi66GMg3qX8Lxf6UYbSQRtWZ" +
                                    "nc9wZmwHxHqhCRET6pfxk07FWvT6nKnLVVQrrQf6tVDyikvgMrvyGUdpA0qtFJMer72JJwEzGAq72" +
                                    "mHgTvjT7yCP6VqVjKQ4ATzPJJAL28kYGKvpRgAvGSvDppQWmk00HtHV7Uy4Qx6bpjVrq6E7wHAKvZ" +
                                    "cCUyJcqrYDX4fbkg6NW9iEEdrNGzf6Yy878NRMZFhfeiT9H0Z0m4c9kLAwuyHcrgBHrqAZcq7gAxG" +
                                    "Dk6Fn1QN3brgTqGi0x29mm7ecj3yiziE6WGADZrZJ9ugKJA6Ck098VQLHEaNZDvgCMV7MbpfAci7w" +
                                    "8pE6b9b0DHiMPuVH9h9zi1Fm1d7tgSVTPg9hS0hPE1VeJ4qB0zfwpBpNV9QRC3CKqpmt92u9jpbRS" +
                                    "ixAD3EvKLJB8rvPm4NYD56g3nFFWqbXRnr9rPipqgPkwdtkntUHZQ3DYY71dNuE8pjaHUJSJ5Lwex" +
                                    "ERWVNSPGwG8NRcHveXuQBRitTFNyB6JCwEYdfwKuVRj5pKAxNBXz3c4i88VurYu5m6czyHCx6S7fZ" +
                                    "KBJ6jmeY3aHyCDuqaXi7B3EeJf0fqpf9jqxpHFe2APATge8n4ihLY0n1a8VuSFTRgEuGCy3FCJ0bP" +
                                    "nHtqTVdn0QNcKG6JiUN57hdN3VUe22m8nnJWTC77KUacM3ttqFyBv0vYGA8gG8JQAiwnd1TbuBYgh" +
                                    "RunYVAHgz6exqZnREwccrAPDV270p6k1Bx1igRUn3b6HVgcy7tMZMZ7RZpitvabWCERTjwfT6qXF7" +
                                    "umS3VVpAWd2NTyNGZ3S5KM42MugmU1z8VwPGfX0jud3GLPPXd5XT1bDcc3XHR4ckVfckBWW7Y7CqE" +
                                    "9dFTYTw7rgvZYAMbebgCDWxYm83EWkMCrBuTx0qzGFAD2ziWjYj5mPqYbJhSvM4MumZqzm5wjJ2hg" +
                                    "CVZ8M7DxRP2pcqYNxx6rj1cuLcCSAU3VmgR4H5QkgynZN2LMgeCKt0Z2L86itqET0QiEFiNJtHqmy" +
                                    "kZSvdB1RDN5729Zhfg437E7r58zycPNMi8mtcWFNSzKZRwM3CpAR7vYXhA4mQA5QPxE4uAe3e76YG" +
                                    "ga3XGTDDqtByiE1dtwWwywudNK0uSBz3ykiJj4wfYJvdKJhYeuccuwJMwBHwgFaWrbrDYSkVyjKQK" +
                                    "d19AcJiaruV8T5CPMNWmSyLzJwXxnVMYiFAUiydgjr74W3kPxKc9jdAAkcN7BiR6MAtCGKt1aEdBg" +
                                    "taR7KBZ8JLPM7Knib8p6uz3bjHgUhSxMXPk7e75TmrbjZhS8Mht0MZ1mZTMUU1JRJiz7GpTQUkn5m" +
                                    "52cWb2nwVufDBxxQwxcyhRqwuerfbdtigQYGG62ZZ9CHG2LxnTF6nkMFP8yCCR18aaqCxnTGE77Ra" +
                                    "cZXEfqjBjTuhkERR6462XJ6fKF6iTpwRUx7njvTb2neTxqQbhNW3bqH9AdfmiWwEvHYEkZrza5403" +
                                    "0ZuDPvxBLLVxvhiGrdhL7feA4XZU1ebLBX1nC3uTUYEbSnqSFpPvgzuCqGeS0xbQyh0M1WtDp");
        // Randomly generated string of size 5001
        const string expected = "Description length cannot exceed 5,000 characters!";
        Project testProject = new Project();
        
        //Act
        string result = testProject.SetDescription(description);
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void SetProjectOwner_ValidUser_ReturnsSuccess() {
        
        //Arrange
        const string expected = ("Project owner set to Smitty Werbenjägermanjensen!");
        Project testProject = new Project();
        User testUser = new User();
        testUser.firstName = "Smitty";
        testUser.lastName = "Werbenjägermanjensen";
        testUser.isSuccess = true;
        
        //Act
        string result = testProject.SetProjectOwner(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void SetProjectOwner_InvalidUser_ReturnsError() {
        
        //Arrange
        const string expected = "This user could not be found.";
        Project testProject = new Project();
        User testUser = new User();
        testUser.isSuccess = false;

        
        //Act
        string result = testProject.SetProjectOwner(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void AddProjectMember_ValidUser_ReturnsSuccess() {
        
        //Arrange
        const string expected = ("Luffy D. Monkey has successfully been added as a member!");
        Project testProject = new Project();
        User testUser = new User();
        testUser.firstName = "Luffy";
        testUser.middleInitial = "D";
        testUser.lastName = "Monkey";
        testUser.isSuccess = true;
        
        //Act
        string result = testProject.AddProjectMember(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void AddProjectMember_InvalidUser_ReturnsError() {
        
        //Arrange
        const string expected = "This user could not be found.";
        Project testProject = new Project();
        User testUser = new User();
        testUser.isSuccess = false;

        
        //Act
        string result = testProject.SetProjectOwner(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void RemoveProjectMember_ValidUser_ReturnsSuccess() {
        
        //Arrange
        const string expected = ("John A. Doe has successfully been removed from members!");
        Project testProject = new Project();
        User testUser = new User();
        testUser.firstName = "John";
        testUser.middleInitial = "A";
        testUser.lastName = "Doe";
        testUser.isSuccess = true;
        testProject.AddProjectMember(testUser);
        
        //Act
        string result = testProject.RemoveProjectMember(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void RemoveProjectMember_InvalidUser_ReturnsError() {
        
        //Arrange
        const string expected = "This user could not be found.";
        Project testProject = new Project();
        User testUser = new User();
        testUser.isSuccess = false;
        
        //Act
        string result = testProject.RemoveProjectMember(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void RemoveProjectMember_ValidUserNotInList_ReturnsError() {
        
        //Arrange
        const string expected = "Fred Flintstone is not a member for this project.";
        Project testProject = new Project();
        User testUser = new User();
        testUser.firstName = "Fred";
        testUser.lastName = "Flintstone";
        testUser.isSuccess = true;
        
        //Act
        string result = testProject.RemoveProjectMember(testUser);
        
        //Assert
        Assert.That(result.Equals(expected));
    }

    [Test]
    public void DisplayProjectMembers_UserList_ReturnsSuccess() {
        
        //Arrange
        const string expected = ("Jotaro Kujo\nGeneric J. Person\n");
        Project testProject = new Project();
        
        User testUserA = new User();
        testUserA.firstName = "Jotaro";
        testUserA.lastName = "Kujo";
        
        User testUserB = new User();
        testUserB.firstName = "Generic";
        testUserB.middleInitial = "J;";
        testUserB.lastName = "Person";

        testProject.AddProjectMember(testUserA);
        testProject.AddProjectMember(testUserB);

        
        //Act
        string result = testProject.DisplayProjectMembers();
        
        //Assert
        Assert.That(result.Equals(expected));
    }
    
    [Test]
    public void DisplayProjectMembers_NoUsers_ReturnsError() {
        
        //Arrange
        const string expected = "There are no users for the project.";
        Project testProject = new Project();
        
        //Act
        string result = testProject.DisplayProjectMembers();
        
        //Assert
        Assert.That(result.Contains(expected));
    }
}