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

---------------------------------------------------------------------------------------------

This app uses Azure Storage:

In order to azure storage emulator, it must be turned on.

If you don't have azure storage emulator, here is the download link provided below:
https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator

Follow the steps to turn on the azure storage emulator:
1. Go to the folder where the emulator executable is found.
	\Microsoft SDKs\Azure\Storage Emulator
2. Type in the following line below:
	AzureStorageEmulator.exe start

This project already has Azure storage installed in the MVC project, and the connection string is added.
In order to use the Azure storage emulator, the Appsettings.json file in your MVC application must have the following line under ConnectionStrings:

"AzureStorageLocalConnection": "UseDevelopmentStorage=true"

In your Startup file, your connection string must be added to the AddAzureServiceClient in the ConfigureServices

builder.AddBlobServiceClient(Configuration["ConnectionStrings:AzureStorageLocalConnection:blob"], preferMsi: true);
builder.AddQueueServiceClient(Configuration["ConnectionStrings:AzureStorageLocalConnection:queue"], preferMsi: true);