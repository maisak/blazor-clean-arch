using BCA.Infrastructure.Database;
using BCA.Infrastructure.Identity.Entities;
using BCA.Web.Components.Account;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;

namespace BCA.Web.Configuration;

public static class SecurityConfiguration
{
	public static WebApplicationBuilder ConfigureSecurityFeatures(this WebApplicationBuilder builder)
	{
		builder.WebHost.UseKestrel(options => options.AddServerHeader = false);
		
		return builder;
	}
	
	public static WebApplication ConfigureSecurityFeatures(this WebApplication app)
	{
		if (!app.Environment.IsDevelopment())
		{
			app.UseHsts();
		}
		
		app.UseHttpsRedirection();
		app.UseAntiforgery();
		
		return app;
	}
	
	public static IServiceCollection AddIdentity(this IServiceCollection services)
	{
		services.AddCascadingAuthenticationState();
		services.AddScoped<IdentityUserAccessor>();
		services.AddScoped<IdentityRedirectManager>();
		services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
		services.AddAuthorization();
		services
			.AddAuthentication(options =>
			{
				options.DefaultScheme = IdentityConstants.ApplicationScheme;
				options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
			})
			.AddIdentityCookies();
		services.AddAuthorizationBuilder();
		services
			.AddIdentityCore<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireNonAlphanumeric = false;
			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<ApplicationDbContext>()
			.AddSignInManager()
			.AddDefaultTokenProviders()
			.AddApiEndpoints();
		services.AddTransient<PasswordHasher<ApplicationUser>>();

		return services;
	}
	
	public static WebApplication MapIdentityEndpoints(this WebApplication app)
	{
		app.MapAdditionalIdentityEndpoints();
		
		return app;
	}
}