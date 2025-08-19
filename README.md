# NET-DDD-Lite-vsix

VS2022 extension (VSIX) that scaffolds a **lightweight DDD** solution with a working **Product/ProductImage** aggregate,
EF Core mapping, provider selection (**SqlServer** or **Postgres**), and optional seeding.

## Build VSIX
```bash
dotnet build ./src/NET-DDD-Lite-vsix/NET-DDD-Lite-vsix.csproj -c Release
# Double-click the produced .vsix to install into Visual Studio 2022
```

## Create a solution
- Visual Studio → Create a new project → **DDD Boilerplate (Clean‑ish)**
- Project name: e.g. `Klasid` → creates `Klasid.Domain`, `Klasid.Application`, `Klasid.Infrastructure`, `Klasid.Api`, `Klasid.Tests`

## Configure DB (appsettings.json in Api)
```json
{
  "Database": {
    "Provider": "SqlServer", // or "Postgres"
    "ConnectionStrings": {
      "SqlServer": "Server=localhost;Database=YourApp;Trusted_Connection=True;TrustServerCertificate=True",
      "Postgres": "Host=localhost;Database=yourapp;Username=postgres;Password=postgres"
    },
    "Seed": true
  }
}
```

## EF Migrations
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add Initial --project <Name>.Infrastructure --startup-project <Name>.Api
dotnet ef database update --project <Name>.Infrastructure --startup-project <Name>.Api
```

Namespaces are automatic via `$rootnamespace$` in templates.
