# Group 6 KSU SWE 4663 Software Project Management

This repository contains all the code, documentation, and other resources related to the Software Project Management (SWE 4663) semester project. 

## Table of Contents
- [Team Members](#Team-Members)
- [Architecture](#Project-Architecture)
- [How to use Project](#Project-How-To's)
  - [Setting up the Environment](#Environment-Configurations)
  - [Executing the Unit Tests](#Execting-Unit-Tests)
  - [Executing the Web Application](#Executing-Web-Application)
- [Test Coverage](#Test-Coverage)
- [Video](#Final-Video-Presentation)



## Team Members

This is a six person team consisting of:

| Name                                                     | Project Role                         |
| -------------------------------------------------------- | ------------------------------------ |
| [Ian Riggins](https://github.com/Riggs275)               | Lead Coder & Repository Manager      |
| [Caroline Roberson](https://github.com/CrypticRadicchio) | Project Manager, Lead Writer, Editor |
| [Monte Russell](https://github.com/Montex2024)           | Coder, UI Designer                   |
| Riley Powell                                             | Writer                               |
| [Sotheary Pong](https://github.com/Theary1123)           | Coder                                |
| [Zachary Powell](https://github.com/Zackiskip)           | Coder                                |



## Project Architecture

This project is split up into 3 modules:

### ProjectLogic

A class library containing the logic behind the management system. The library is designed with the intent of promoting high cohesion and loose cohesion as well as reusability.

### ProjectLogicUnitTests

Multiple sets of test cases to ensure that all the features of the ProjectLogic work as intended when isolated. This module references the ProjectManagerLogic namespace.

### ProjectManagerWebServer

A web application built with Blazor that provides a user interface (UI) and handle interactions with the user. This module references the ProjectManagerLogic namespace.

### Visualization

Below is a visual representation of how the project's architecture

<img src="Images/SWE 4663 Class Diagram v4.png" alt="A class diagram indicating the projects architecture" style="zoom;" />



## Running the Project

### Environment Configurations

This is a cross-platform application and it should work on Windows 10+, Mac OS, and Linux environments.<br>
***Disclaimer**: This application has only been tested in Windows 11.*

<ins>Here are the steps to preparing your environment to execute this application:</ins>

<ol>
  <li><b>Install the .NET 8.0 SDK:</b> Install the .NET Software Development Kit (SDK) from the official Microsoft website. This is one of the most important steps since .NET 8.0 or higher is required in order for this to run.</li>
  <li><b>Clone this Repository:</b> Download or clone the repository to your machine (both options give the same result) and store it in whatever preferred directory you desire.</li>
  <li><b>Build the Application:</b> Once you've extracted the repository and have it in your desired directory, you'll either need to access your command line or an Integrated Development Environment (IDE).</li>
  <ul>
    <li><b>Using the command line:</b> After accessing your command line via Commamd Prompt (Windows) or Terminal app (Mac). Navigate to the directory where the repository was cloned/downloaded. From there you can access the solution file (.sln) and build the project. Below is an example of what you need to put in your command line (assuming the directory is located on your Desktop).</li>
    <li><b>Using an IDE:</b> After setting up your IDE (assuming everything is set up correctly), open the project in your IDE and press the build button.</li>
  </ul>
</ol>
<br>
<ins><b>Example:</b></ins>

```Bash
cd Desktop/Group-6-SWE-4663-Project/src
dotnet build
```


From here you can run the Unit Tests or Web Application!

### Executing Unit Tests

After [configuring your environment](#Environment-Configurations) and building the solution, you can execute unit tests to ensure everything is functioning properly. To do this you will navigate to the directory and run the test command.

<br>
<ins><b>Command Line Example:</b></ins>

```Bash
cd Desktop/Group-6-SWE-4663-Project/src/ProjectLogicUnitTests
dotnet test
```

If everything was done correctly, you should receive an output that looks identical  to the one below

```Bash
Starting test execution, please wait...
A total of 6 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:   103, Skipped:     0, Total:   103, Duration: ms - ProjectLogicUnitTests.dll (net8.0)
```

### Executing Web Application

After [configuring your environment](#Environment-Configurations), you can execute the web application. To begin, you will need to naviagate to the ProjectManagerWebApp directory and run the command.

<br>
<ins><b>Command Line Example:</b></ins>

```Bash
cd Desktop/Group-6-SWE-4663-Project/src/ProjectManagerWebApp
dotnet run
```

Assuming everything was done correctly, you should receive an output that looks similar to the one below

```Bash
Building...
info: Microsoft.Asp.Net.Core.DataProtection.KeyManagement.XmlKeyManager[63]

info: Microsoft.Hosting.Lifetime[14]
      Now listening on http://localhost:1234
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting enviornment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path:
```

From here, you can launch a web browser of your choice and type in the URL that the command line gave you.

## Test Coverage

The Test Coverage statistics for *ProjectManagerLogic* and *ProjectLogicUnitTests* are as follows:

**Unit Test Success:** <img src="Images/Unit Test Success.png" alt="The final set of unit tests all succeeding" style="zoom;" />



**Unit Test Coverage:**

 <img src="Images/Unit Test Coverage.png" alt="The final set of Unit Tests and how many statements the covered in the system" style="zoom;" />

99.31% Statement Coverage was achieved for the *ProjectManagerLogic* module and 100% Statement Coverage was achieved for the *ProjectLogicUnitTests* module. Altogether, 99.7% Statement Coverage has been achieved.




## Final Video Presentation