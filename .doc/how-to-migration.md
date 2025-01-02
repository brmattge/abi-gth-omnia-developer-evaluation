[Back to README](../README.md)

# Running Migrations

To run migrations in your project, follow the steps below using **Entity Framework Core (EF Core)** and PostgreSQL. Make sure you're working in the correct project path: `abi-gth-omnia-developer-evaluation\template\backend\src\Ambev.DeveloperEvaluation.WebApi`.

### Step 1: Install dotnet-ef (if needed)
First, ensure that the `dotnet-ef` tool is installed globally. If not, use the following command in the terminal:

```bash
dotnet tool install --global dotnet-ef
```

### Step 2: Add a Migration
To create a new migration, execute the following command to add a new migration:

```bash
dotnet ef migrations add MigrationName
```

### Step 3: Apply the Migration to the Database
After creating the migration, apply the changes to the PostgreSQL database by running the following command:

```bash
dotnet ef database update
```

### Full Example
Given that you're using .NET 8.0 and Npgsql.EntityFrameworkCore.PostgreSQL, an example of creating and applying the initial migration would be:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

This will create the tables in your PostgreSQL database.
