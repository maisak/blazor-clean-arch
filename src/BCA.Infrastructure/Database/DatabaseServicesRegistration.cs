using BCA.Application.Contracts;
using BCA.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BCA.Infrastructure.Database;

public static class DatabaseServicesRegistration
{
	public static IServiceCollection AddDatabaseServices(this IServiceCollection services, 
		IConfiguration configuration)
	{
		services.AddDbContext<ApplicationDbContext>(options =>
			options
				.UseSqlServer(configuration.GetConnectionString("Default"))
				.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
				.EnableSensitiveDataLogging());

		services.AddScoped<ITodoListsRepository, TodoListsRepository>();
        
		return services;
	}
}