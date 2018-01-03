# 1. Architecture of this project

The projects are the following 

\Workloud.Challenge.Business
This project contains a set of core services, business logic, validations or calculations related with the data, if needed.

\Workloud.Challenge.DataAcceess
This is the layer for reading and writing to a database. It helps separate data-access logic from our business objects.
It uses Entity Framework.

\Workloud.Challenge.Domain
This contains all the business objects (for example Employee).

\Workloud.Challenge.Abstractions
Includes all the interfaces.

\Workloud.Challenge.WebService
This a Web API project. 

\Workloud.Challenge.WebApplication
This a ASP.NET MVC application project (Web Client), a presentation layer for the CRUD operations. It consumes the 
API's from the Web Service layer via RestSharp (http://restsharp.org/). 

# 2. Inversion of Control and Dependency Injection.

Τhe Web Service Tier uses ninject library (http://www.ninject.org/) as its IoC container.

# 3. Database Creation.

Fot the database creation in MS SQL Server or Express, add a new one with name WorkloudChallenge.
Then execute the script create-db-entities-scripts which is inside sql-scripts folder.

# 4. How to run the project.
Set Workloud.Challenge.WebApplication as the start up project in order to run it locally.
