using BCA.Application.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BCA.Application;

public static class ApplicationServicesRegistration
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		var assemblies = AppDomain.CurrentDomain.GetAssemblies();
		services.AddValidatorsFromAssemblies(assemblies);
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
	
		return services;
	}
}