using BCA.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BCA.Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
	: IdentityDbContext<ApplicationUser>(options)
{
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
        
		var configurations = GetConfigurations();

		foreach (var configuration in configurations)
		{
			dynamic configurationInstance = Activator.CreateInstance(configuration)!;
			modelBuilder.ApplyConfiguration(configurationInstance);
		}
	}
	
	private static IEnumerable<Type> GetConfigurations()
	{
		var types = Assembly
			.GetExecutingAssembly()
			.GetTypes()
			.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && 
												   i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));
		return types;
	}
}
