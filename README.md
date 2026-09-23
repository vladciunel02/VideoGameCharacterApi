# Video Game Character API

Simple Web API for managing video game characters. Built with .NET 10, EF Core, and SQL Server, with basic CRUD (get, add, update, delete).

Character has: Id, Name, Game, Role.

## Running it

1. Clone the repo
2. Set your SQL Server connection string in `appsettings.json`
3. Run `Update-Database` to apply migrations
4. Run the project

## Endpoints

- GET /api/VideoGameCharacter
- GET /api/VideoGameCharacter/{id}
- POST /api/VideoGameCharacter
- PUT /api/VideoGameCharacter/{id}
- DELETE /api/VideoGameCharacter/{id}

## Tests

There's a separate test project, `VideoGameCharacterApi.Tests`, with unit tests for the service layer (`VideoGameCharacterService`), using NUnit.

The tests run against an EF Core in-memory database instead of real SQL Server, so they're fast and don't need any setup. Each test gets its own clean, isolated database.

Covered so far:
- adding a character and getting back a valid id
- getting a character by id, both when it exists and when it doesn't
- getting the full list of characters

Not covered yet: updating and deleting a character.

Run with:

```
dotnet test
```

## CI and code quality

Every push and pull request to `master` runs a GitHub Actions workflow (`.github/workflows/ci.yml`) that:

1. builds the solution on a fresh Linux machine
2. runs all the NUnit tests and collects code coverage
3. sends the code and the coverage report to SonarQube Cloud for analysis

SonarQube Cloud checks the code for bugs, code smells, duplication and security issues, and shows which lines the tests actually cover. The badges at the top show the current results.
