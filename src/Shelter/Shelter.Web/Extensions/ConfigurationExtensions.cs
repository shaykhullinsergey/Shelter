using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class ConfigurationExtensions
	{
		private static void AddServiceConfiguration(this IServiceCollection services, ServiceSection section)
		{
			services.AddSingleton(section);
			services.AddSingleton(section.Credentials);
			services.AddSingleton(section.Services);
			services.AddSingleton(section.Jwt);
		}

		public static TConfiguration AddShelterConfiguration<TConfiguration>(this IServiceCollection services, IConfiguration configuration)
			where TConfiguration : Configuration
		{
			var instance = Activator.CreateInstance<TConfiguration>();
			
			configuration.Bind(instance);

			services.AddSingleton(instance);
			services.AddServiceConfiguration(instance.Service);
			return instance;
		}
	}
}