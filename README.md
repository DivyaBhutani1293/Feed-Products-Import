# Feed-Products-Import

Installation Steps:
Install the Visual Studio 2017 on machine

Where to find the code:
https://github.com/DivyaBhutani1293/Feed-Products-Import.git


How to run the code / tests:

Build the code and add following packages to solution if getting error:
Soution1 - Import:
Packages to be installed - 
System.CommandLine
System.ComandLine.NamingConventionBinder
NewtonSoft.json
YAMLDotNet


Solution2 - Import.Tests:
Packages to be installed - 
Microsoft.Net.Test.Sdk
Moq
NUnit
NUnit3TestAdapter

Also, add the Solution1 reference to Test project after building the project

For code publishng -
dotnet publish -c debug -r win10-x64  --> this will generate .exe file located in bin/Debug/netcoreApp2.1/win10-x64
-c --> want to use debug configuration
-r --> application will run on Windows platform with x64 architecture

Pack the tool. Go to build --> Pack <solution-name>

Install the tool globally:
dotnet install --global
--add-source  <project-root-path>/bin/debug <tool-name>


Running the tool:

Input:
>import <product-name> <file-path-along-with-extension>

Output:
importing: Name: "GitHub";  Categories: Bugs & Issue Tracking, Development Tools; Twitter: @github
importing: Name: "Slack"; Categories: Instant Messaging & Chat, Web Collaboration, Productivity; Twitter: @slackhq


Running the test case:
Change the path in test case file(if required) according to the local path in the system and then run the test case 



Application overview:

Import project:
Model --> Contains classes which are used while deserializing JSON or YAML data
Business Logic --> Wrapper class for code maintenance and fetching JSON data in program.cs main method
Program.cs --> Contains the event handler and when the user provides the input, it will generate the output in the requested format after parsing json/yaml file.

Import.Tests project -->
UnitTest1.cs --> Contains the test case for methods created in business logic folder for functionality testing


Note: Since I was facing issues with Visual Studio 2019 set up, I had to proceed with Visual Studio 2017 and it supports .net core version 2.
If I had VS 2019, I would have implemented the solution in different way using Nuget package CommandLineTool

