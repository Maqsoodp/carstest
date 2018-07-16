# Cars Test

### Description
-----------
Consume a web service that has been created here. The API contains a number of cars, their colours and their owners.
 
Please create an application that does the following:
- Produces a list of the owners' names, grouped by their car's brand alphabetically, and sorted by their car's colour alphabetically.
- Produces a replica service that returns the same results as the API provided.


### Solution Contains

* Rest api built using ASP NET Core 2.0 Web API
* Library to deal with external API
* In memory Database
* Unit test
* Front end SPA built using Angular 5 along with Angular cli

### Development
The solution contains two parts -

Code
* Cars.Api with SPA application
* Cars.Domain - Replica of Kloud api
* Cars.Kloud.Api - Handler to Kloud api

Test
* Cars.Api.UnitTest using Nunit to test the Apis. 
* Cars.Kloud.Api.UnitTest is another unit testing project using Nunit Framework to test Externl Api handler library.

### Build and run code
Open the solution in visual studio IDE and press F5. this will launch a web application.

##### Navigate to Cars tab, (Solution for problem statement 1) :


```sh
Clicking on Car list brings all the list of cars 
```

```sh
 Clicking on Owners grouped by Cars will get you all the Owners listed under each car order by owners then by colour.
```

##### Navigate to Owners tab (Solution for problem statement 2):
```sh
External (Call to Kloud Api) gets you data from Kloud api
```

```sh
Internal (Call to local DB) gets you data from Local Db which is a replica of Kloud api
```




