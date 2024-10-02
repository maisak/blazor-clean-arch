# Blazor demo project
A simple yet robust implementation of **clean architecture** in .NET. This project demonstrates my approach to building apps from the ground up, incorporating best practices I've developed over time.

## Features
### Clean Architecture
The project is structured using the clean architecture pattern. This pattern is designed to separate concerns and make the codebase more maintainable and scalable.
### Solution Structure
![Solution](/docs/solution-overview.png)
- 🗁 files - contains solution level files like `.gitignore`, `license`, `readme.md`, etc.
- 🗁 src - contains projects which are part of the solution.
  - 🗁 Application - application services and feature logic.
  - 🗁 Domain - domain entities.
  - 🗁 Infrastructure - contains implementation of infrastructure services like database, email, etc.
  - 🗁 Web - UI project, basically representation layer.
- 🗁 tests - TBD
- 🗁 scripts - `powershell` scripts to automate every-day developer tasks.

### Settings and configuration
+ ⚙️ Prefer creating an `appsettings.development.json` to store configuration in development environment. File is excluded from version control. This approach is simpler than using user secrets and absolutely safe.
![Settings](/docs/settings.png)

### Scripts
+ 📃 `scripts` folder contains `powershell` scripts to automate every-day developer tasks.
```powershell
.\get-paths.ps1

Context        : ApplicationDbContext
DataProject    : C:\Source\blazor-clean-arch\src\BCA.Infrastructure\BCA.Infrastructure.csproj
Migrations     : C:\Source\blazor-clean-arch\src\BCA.Infrastructure\Database\Migrations
Root           : C:\Source\blazor-clean-arch
StartupProject : C:\Source\blazor-clean-arch\src\BCA.Web\BCA.Web.csproj
```
```powershell
.\add-migration.ps1 "TodoLists"

Build started...
Build succeeded.

Done. To undo this action, use 'ef migrations remove'
```
### Authentication and Authorization
+ 🚧 TBD

### EF Core
The project uses Entity Framework Core as the ORM.

+ ☑️ `Code First` approach.
+ ☑️ `Migrations` are applied automatically on application start.
+ ☑️ `Soft delete` implemented using `DeletedAt` column. Obviously not all entities need to be `ISoftDelete`'able, so there is a logic to distinct them.
+ ☑️ `Change tracking` turned off by default. In those rare cases when I need to retrieve an entity, change it and save back - I will use `.AsTracking()`.

### Validation
+ ✅ `FluentValidation` is used for validation. Validation rules are incapsulated in `DTO`s they suppose to validate. The process itself happens in `MediatR`'s pipeline.

### Logging
+ 🚧 TBD

### Error handling
+ 🚧 TBD

### CI/CD
+ 🚧 TBD

### Tests
+ 🚧 TBD

### Security
+ 🚧 TBD