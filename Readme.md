# Sneaker collection

This project used clean architecture and follow some DDD principles.

## Installation

- Clone the project
- Open Package Manager Console
- You will now do the migration: Add-Migration Name
- Once its done, you will need to update with: Update-Database

## Run the app

- Then, hit F6 (if you're on Visual Studio)
- A page with Swagger and the Apis will be displayed.

## Access

The endpoints below are restricted for Admin only. You will need to create an account with `Admin` role by using `POST register`.
`POST Sneaker`
`DELETE Sneaker`
`PUT Sneaker`

The endpoints below are not restricted. So, Admin and User can use them.
`GET Sneaker`
`GET Sneaker By Id` 
`GET GetAllFilter`

## API

List of the API:

### Register

`POST /api/Authentification/register` 

Create an account with an email, username, password and role.

Note: There are only two roles availables: `Admin` and `User`.

### Login

`POST /api/Authentification/login` 

How to loggin:

- Use the email and password from the Register request (above).
- In the Response Body you will have a token.
- Copy and past in the [Authorize] button at the top of the page.
- You should be logged.

### Get all the sneakers

`GET /Sneaker`

### Get a sneaker by Id

`GET /Sneaker/{id}`

### Create a new Sneaker

`POST /Sneaker`

### Delete a Sneaker

`Delete /Sneaker/{id}`

### Update a Sneaker

`PUT /Sneaker/{id}`

### Search by Brand or Name or Price

`PUT /Sneaker/GetAllFilter`

## Improvement for later (Missing)

- Adding unit tests (XUnit Test).
- Add error handling for the Api.
- Add strong type for sneaker entity. Ex: DateTime instead of int for year. I used int for the simplicity.

## Note

During the development of the project, I omitted certain principles because I considered them not useful for the scope of the project. You can check below my point of view:

- I didn't use Domain events because I have only one AggregateRoot (Sneaker). I don't need to an operation during parallel task.

- As I am using EF, the unit of work pattern is implemented by a DBContext and is executed when a call is made to `SaveChange`. (https://learn.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design).

- We are using an anemic domain model for simplicity but for complex cases, I would suggest to implement data model object instead of domain entities.

- I didn't create a value object because I believe it wasn't interested to do one for Sneaker.
