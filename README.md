# Blazor demo project
A simple yet robust implementation of **clean architecture** in .NET. This project demonstrates my approach to building apps from the ground up, incorporating best practices I've developed over time.

## Features
### Clean Architecture
The project is structured using the clean architecture pattern. This pattern is designed to separate concerns and make the codebase more maintainable and scalable.
### Solution Structure
![Solution](/docs/solution-overview.png)
### EF Core
The project uses Entity Framework Core as the ORM.
- [x] `Code First` approach.
- [x] `Migrations` are applied automatically on application start.
- [x] `Soft delete` implemented using `DeletedAt` and `DeletedBy` columns.
- [x] `Change tracking` turned off by default.

```csharp
services.AddDbContext<ApplicationDbContext>(options =>  
    options  
       .UseSqlServer(configuration.GetConnectionString("Default"))  
       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)  
       .EnableSensitiveDataLogging());
```

In those rare cases when I need to retrieve an entity, change it and save back - I will use `.AsTracking()`.