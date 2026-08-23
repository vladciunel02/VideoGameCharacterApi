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
