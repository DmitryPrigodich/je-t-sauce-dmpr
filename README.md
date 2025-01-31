# je-t-sauce-dmpr
C#-based Playwright autotest project

# The Task
>Please create an automated test script that follows the provided test case for buying a T-shirt on the Sauce Labs Sample Application (https://www.saucedemo.com/). The test script should be implemented using C# as the programming language and Playwright for browser automation. To collaborate on this task, please create a new repository on any Git hosting platform of your choice (e.g., GitHub, GitLab, Bitbucket). 

> Additional task: create yml pipeline. save credentials as secret and add step in pipeline with asking credentials before pipeline starts executing.

> Once you have completed the test script, we would be happy to receive the source code from you as a repo on/or before Friday, 31st January 2025


* Tech: C#/Playwright/Git
* Site: ```https://www.saucedemo.com/```
* Task: Create an automated test case for buying a T-shirt
* Additionally:
  * create YML pipeline
  * save credentials as secret
  * add step in pipeline with asking credentials before pipeline starts executing
* Deadline: 2025.01.31


## Setup
* go to project folder
* ```dotnet new xunit```
* ```dotnet add package Microsoft.Playwright```
* ```dotnet tool install --global Microsoft.Playwright.CLI```
* ```dotnet build```
* ```playwright install```

## Launching
* ```dotnet test```
* ```dotnet test --filter "Name=YourTestMethodName"```
* ```dotnet test --filter "FullyQualifiedName=Namespace.ClassName.MethodName"```