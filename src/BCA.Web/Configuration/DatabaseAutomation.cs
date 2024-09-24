using BCA.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace BCA.Web.Configuration;

public static class DatabaseAutomation
{
	public static async Task MigrateDatabase(this WebApplication webApplication)
	{
		using var scope = webApplication.Services.CreateScope();
		try
		{
			var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
			await context.Database.MigrateAsync();
		}
		catch (Exception ex)
		{
			var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
			logger.LogError(ex, "Automatic DB migration failed.");
		}
	}
}