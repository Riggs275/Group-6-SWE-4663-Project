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



## Team Members

This is a six person team consisting of:

| Name                                                     | Project Role                         |
| -------------------------------------------------------- | ------------------------------------ |
| [Ian Riggins](https://github.com/Riggs275)               | Lead Coder & Repository Manager      |
| [Caroline Roberson](https://github.com/CrypticRadicchio) | Project Manager, Lead Writer, Editor |
| [Monte Russell](https://github.com/Montex2024)           | Coder, UI Designer                   |
| [Riley Powell](https://github.com/Rpowell57)             | Writer                               |
| [Sotheary Pong](https://github.com/Theary1123)           | Coder                                |
| [Zachary Powell](https://github.com/Zackiskip)           | Coder                                |

## Project Architecture

This project is split up into 3 modules:

### ProjectLogic

### ProjectLogicUnitTests

### ProjectManagerWebServer

### Visualization

<img src="Images/SWE 4663 Project Class Diagram v3.png" alt="A class diagram indicating the projects architecture" style="zoom;" />



## Running the Project

### Environment Configurations

This is a cross-platform application and it should work on Windows 10+, Mac OS, and Linux enviornments.<br>
***Disclaimer**: This application has only been tested in Windows 11.*

<ins>Here are the steps to preparing your environment to executing this application:</ins>

<ol>
  <li><b>Install the .NET 8.0 SDK:</b> Install the .NET SDK from the [official Microsoft website](https://dotnet.microsoft.com/en-us/download), please keep in mind that this project needs .NET 8.0 in order to run.</li>
  <li><b>Clone the Repository:</b> Download or clone the repository to your machine (both options givs the same result) and store it in whatever preferred directory you desire.</li>
  <li><b>Build the Application:</b> Once you've extracted the repository and have it in your desired directory, you'll either need to access your command line or an IDE (Integrated Development Environment).</li>
  <ul>
    <li><b>Using the command line:</b> After accessing your command line via Commamd Prompt (Windows) or Terminal app (Mac). Navigate to the directory where the repository was cloned/downloaded. From there you can access the solution file (.sln) and build the project. Below is an example of what you need to put in your command line (assuming the directory is located on your Desktop).</li>
    <li><b>Using an IDE:</b> After setting up your IDE (assuming everything is set up correctly), open the project in your IDE and press the build button.</li>
  </ul>
</ol>

<br><ins><b>Example:</b></ins>
```Bash
cd Desktop/Group-6-SWE-4663-Project/src
dotnet build
```


From here you can run the Unit Tests or Web Application!

### Executing Unit Tests

### Executing Web Application

## Test Coverage

