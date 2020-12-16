This application is split into multiple projects:

1. IguanaTracker.API
2. IguanaTracker.BL
3. IguanaTracker.Data
4. IguanaTracker.Web.MVC

The project runs on a .Net Core MVC application.  For the API project, it is not being used now, but it will be used in the future for other web projects, like Angular, React, or Blazor.

The project requires the connection to a SQL Server database, so I provided a script to generate that database with the table that holds the records of sightings, and run it first.
Also, change the connection string in the appsettings.json file to match the connection to the database.

The application is published onto Azure as "Florida Iguana Tracker".  Here is the link below:

https://www.floridaiguanatracker.com/