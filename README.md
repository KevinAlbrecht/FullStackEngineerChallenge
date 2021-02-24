# Full Stack Developer Challenge


#### Technical stack:
 - Api: Aspnet core 3.1
 - Database MSSQL
 - Front: Angular 10
 
#### Folder structure:
 - Paybaymax.Data : POCO + database context.
 - Paybaymax.Database
	 - dbo: contains tables schema
	 - scripts: scripts to init the database
 - Paybaymax.Domain : queries and commands + repositories
 - Paybaymax.Models : DTOs
 - Paybaymax.Web: Api
 - Paybaymax.Web\ClientApp : Front End ( hosted by the api itself )
 
#### How to run it :
##### Database
Run the scripts: 
> 0001-init_database.sql
>0002-seed.sql

(named as if db migration tools was used )

##### Front dependencies

In the client app folder

```npm install```
or
```yarn install```

##### Run app
on the Paybaymax.Web project
```dotnet run```

(the dotnet command will launch front end as well, but both can be launched separately if needed ).

### Api routes
 - "api/auth"
	 - Login: [Post] "" 
	 - Logout: [Post] "/logout"
 - "api/employee"
	 - Get all employees: [Get] "all"
 - "api/feedback"
	 -  Create feedback: [Post] ""
 - "api/performance"
	 - Admin user
		 - Get all perfs : [Get]  ""
		 - Create perf: [Post] ""
		 - Update perfs: [Put] "/{id}"
		 - Assign employee to review : [Post] "/assign"
	 - All users
		 - Get assigned perfs : [Get] "/assigned"

### Angular modules
Client module :
 - Access the login page
 - Access to the performances page
	 - List all assigned performance reviews
	 - Can create a feedback

Admin module: 
 - Access a full performances page
	 - Can create/ update a performance
	 - Can assign an employee to a performance

Shared modules contains  every trans-modules components, route guards, interceptors, models and services.

### Comments &  assumptions
##### Error handling:
 only example are provided: 
 - Backend:
	 - In the Auth controller, que query will throw a business exception handled by the controller.
 - Front end: In the Login page with login component
##### Front 
No state management, simply try to separate in modules, and split a maximum the services/components and tried to keep a one way flow of data Parent --data--> children | children --event--> parents.

##### Authentication
I assumed, because of the light complexity of the app, the front is hosted in the same domain as the back so we don't need a JWT, and a simple httpOnly secure auth cookie is provided.

##### Business 
Assignment to feedback : I assumed Admins can be dev as well and can participate into Performance review feedback.
