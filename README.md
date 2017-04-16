AgeRanger App - Marcus Tham (mykltham[at]gmail.com)
***************************************************

1. Project Architecture
-----------------------
a) ASP.NET MVC
b) WebAPI
c) AngularJS (Front-end) - Single Page Application
d) Entity Framework 

2. NuGet Packages
-----------------------
a) Entity Framework 6.1.3
b) AngularJS 1.6.3
c) jQuery 3.1.1
d) System.Data.SQLite 1.0.105.0
e) System.Data.SQLite.Core 1.0.105.0
f) System.Data.SQLite.EF6.1.0.105.0
g) System.Data.SQLite.Linq.1.0.105.0

3. Tools:
----------
a) Visual Studio 2013 Community Edition

4. To run:
----------
a) Open "AgeRanger.SPA.sln", build it, and run.

5. To migrate to MSSQL:
-----------------------
a) Open "Repositories > PersonRepository.cs > GetAllWithAgeGroup()", use the "strSQL for MSSQL".
b) Updated "Web.Config > <connectionStrings> > AgeRangerEntities"

