Setup Electronic Medical Record - API local

Prerequisites:

1) Mongo
2) Visual studio 2019
3) ASP.NET and web development workload
4) .Net Core 3.0

Project setup:

1) Change connection strings in order to work with your local databases in appsettings.json
2) Since it's code-first approach, you need to run into package manager console commands for migrations and database:
       
       1. add-migration migrationName
       2. update-database



