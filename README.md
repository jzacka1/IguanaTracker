# IguanaTracker
This is an application where users can report sightings of iguanas in Florida.

Users can upload images to application, type in the location and give the information about the sighting.

This project needs a database to run on, so I attached a SQL script that'll generate the database for SQL Server.
The script is called 'iguanaTrackerScript'.  Run it SQL Server, and it'll create the database and create the table for you.

To connect to the database, change the connection string properties in the appsettings.json files to match the database you want to target.

This solution is split into 5 projects

1. Angular 
2. Business Logic
3. Data
4. MVC
5. API

*Note*
The solution's startup project is 'IguanaTracker.Web.MVC'.
Also, I didn't put in the work for the Angular project.
If you would like to work on the Angular project, feel free to try to do so.
You can also use the API provided in the solution.
