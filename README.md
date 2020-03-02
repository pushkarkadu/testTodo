

DB server: MSSQL
database server name : (localdb)\\MSSQLLocalDB
database name: MyApplicationDb

Steps to Start The Host:
1. Open your solution in Visual Studio 2019
2. Open the Package Manager Console and run dotnet restore command to restore packages.
3  Build the solution.
4. Select the 'Web.Host' project as the startup project.
5. Check the connection string in the appsettings.json file of the Web.Host project, change it if you need to.
6. Open the Package Manager Console and run an Update-Database command to create your database (ensure that the Default project is selected as .EntityFrameworkCore in the Package Manager Console window).
7. Run the application. It will show swagger-ui if it is successful:


Host will start on http://localhost:21021

========================================================================================================================

Steps to Start The Client:

=>Requirements
  The Angular application needs the following tools installed:
	-nodejs 6.9+ with npm 3.10+
	-Typescript 2.0+

1. Open a command prompt, navigate to the angular folder which contains the *.sln file and run the following command to restore the npm packages:==> npm install
2. In your opened command prompt, run the following command:==> npm start

client will start on http://localhost:4200

----------------------Default Login credentials:------------------------------------------------------------

username: admin
password: 123qwe

