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
}