using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class ConfigurationExtensions
	{
		public static void AddServiceConfiguration(this IServiceCollection services, ServiceConfiguration configuration)
		{
			services.AddSingleton(configuration);
			services.AddSingleton(configuration.Credentials);
			services.AddSingleton(configuration.Services);
			services.AddSingleton(configuration.Jwt);
		}
	}
}