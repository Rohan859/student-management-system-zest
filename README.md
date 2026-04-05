# Student Management API

A .NET 9 Web API for managing students with JWT authentication, Entity Framework Core SQL Server storage, and Swagger documentation.

## Project structure

- `StudentManagementAPIZestIndia/` - main web API project
- `StudentManagementAPIZestIndia/Program.cs` - app startup and service registration
- `StudentManagementAPIZestIndia/Controller/` - API controllers
- `StudentManagementAPIZestIndia/Database/` - EF Core DbContext
- `StudentManagementAPIZestIndia/DTO/` - request DTO models
- `StudentManagementAPIZestIndia/Model/` - entity models
- `StudentManagementAPIZestIndia/Migrations/` - EF Core migrations

## Prerequisites

- .NET 9 SDK
- SQL Server or SQL Server Express
- Optional: `dotnet-ef` tool for database migrations

## Setup

1. Open a terminal in the project folder:

```powershell
cd e:\Zest\student-management-system-zest\StudentManagementAPIZestIndia
```

2. Restore packages:

```powershell
dotnet restore
```

3. Build the project:

```powershell
dotnet build
```

4. Ensure the database connection string in `appsettings.json` is valid.

Default connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

If `SQLEXPRESS` is not available, change it to a valid local SQL Server instance, for example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=StudentDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

5. Apply migrations and create the database:

```powershell
dotnet ef database update
```

If `dotnet ef` is not installed, install the global tool:

```powershell
dotnet tool install --global dotnet-ef
```

## Run the API

From the project folder:

```powershell
dotnet run
```

By default, the API runs in `Development` mode and exposes Swagger UI when launched.

Open the Swagger UI in your browser at:

```text
https://localhost:5252/swagger/index.html
```

## Authentication

The API uses JWT authentication.

Login endpoint:

```http
POST /api/Auth/login?username=admin&password=password
```

If successful, the response returns a JWT token:

```json
{ "token": "<jwt-token>" }
```

Use the token for protected student endpoints:

```http
Authorization: Bearer <jwt-token>
```

## Student API endpoints

All student endpoints require a valid Bearer token.

- `POST /api/Student`
  - Body:
    ```json
    {
      "name": "John Doe",
      "email": "john@example.com",
      "age": 22,
      "course": "Computer Science"
    }
    ```

- `GET /api/Student`
  - Returns a list of students.

- `PATCH /api/Student/{id}`
  - Body:
    ```json
    {
      "email": "newemail@example.com",
      "course": "Mathematics"
    }
    ```

- `DELETE /api/Student/{id}`
  - Deletes the student with the specified ID.

## Notes

- Swagger is enabled only in Development mode.
- The sample login hardcodes credentials as `admin` / `password`.
- `StudentRequestDTO` requires `Name`, `Email`, `Age`, and `Course`.
- `StudentUpdateDTO` supports updating `Email` and `Course`.

## Troubleshooting

- If the app fails to connect to SQL Server, verify the connection string and the SQL Server service state.
- For HTTPS redirect warnings, ensure the launch profile or the project is configured with an HTTPS URL.
- If migrations fail, confirm the `StudentManagementAPIZestIndia.csproj` contains `Microsoft.EntityFrameworkCore.SqlServer` and `Microsoft.EntityFrameworkCore.Tools`.
