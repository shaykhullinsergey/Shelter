using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shelter
{
	public static class ConfigurationExtensions
	{
		public static void AddTypedConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			var instance = new AuthConfiguration();
			configuration.Bind(instance);

			services.AddSingleton(instance);
			services.AddServiceConfiguration(instance.Service);
		}
	}
}