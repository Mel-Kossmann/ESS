# ESS
Employee Storage Service for companies

# Requirements
Visual Studio 
SQL Server
Browser

If you have not build a dotnet core application on your device before you can download the following SDK
.NET Core 3.1
Download it here: https://dotnet.microsoft.com/download

The database is a MSSQL db: a script of the DB can be found in the DB folder
once the db is created you can restore the .bak file to import all the data

Open the solution in VS or any other code editor
In Solution Explorer navigate to appsettings.json 
Update the ESSConnection Server to your own server name. (dot = localhost)
Visual Studio will install all the missing packages required to run the application

When all the above is up and running, you can click on the run button.
Your browser should open on localhost:44317

Once the page loads, you will be able to:
Have a small about page (click on ESS)
navigate between pages
view employees
add employees
edit employees
delete employees
add company
edit company
delete company
view the average salary per company
Detailed view per company