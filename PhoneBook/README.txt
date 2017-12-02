
Note: This application uses the Code first EF approach and is targeting .Net Core and all its technologies.

Web Application:

Make sure you connected to a database.

Tools –> NuGet Package Manager –> Package Manager Console

Run "Add-Migration InitialCreate" to scaffold a migration to create the initial set of tables for your model. If you receive an error stating The term 'add-migration' is not recognized as the name of a cmdlet, close and reopen Visual Studio.

Run "Update-Database" to apply the new migration to the database. This command creates the database before applying migrations.


Info: The code is not commented but the naming convetions will guide you through. Enjoy... :-)


Techonologies:
 - Entity Framework Core 1.1.0
 - MS SQl Sever 2008
 - Asp.Net Core 1.1
 - MVC Patten 
 - For Dependency Injections -> Statup.cs
