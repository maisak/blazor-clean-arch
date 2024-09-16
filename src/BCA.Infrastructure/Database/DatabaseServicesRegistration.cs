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
				.EnableSensitiveDataLogging());
        
		return services;
	}
}