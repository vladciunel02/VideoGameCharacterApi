# Video Game Character API

Simple Web API for managing video game characters. Built with .NET 10, EF Core, and SQL Server, with basic CRUD (get, add, update, delete).

Character has: Id, Name, Game, Role.

## Running it

1. Clone the repo
2. Set your SQL Server connection string in `appsettings.json`
3. Run `Update-Database` to apply migrations
4. Run the project

## Endpoints

- GET /api/character
- GET /api/character/{id}
- POST /api/character
- PUT /api/character/{id}
- DELETE /api/character/{id}

## Tests

There's a separate test project, `VideoGameCharacterApi.Tests`, with unit tests for the service layer (`VideoGameCharacterService`), using NUnit.

The tests run against an EF Core in-memory database instead of real SQL Server, so they're fast and don't need any setup, each test gets its own clean, isolated database.

Covered so far:
- adding a character and getting back a valid id
- getting a character by id, both when it exists and when it doesn't
- getting the full list of characters

Not covered yet: updating and deleting a character.

Run with:

```
dotnet test
```
