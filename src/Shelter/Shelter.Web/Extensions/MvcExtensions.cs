using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Shelter
{
	public static class MvcExtensions
	{
		public static IMvcBuilder AddShelterMvc(this IServiceCollection services)
		{
			return services.AddMvc(options =>
				{
					options.Filters.Add<ModelStateFilter>();
				})
				.AddJsonOptions(options =>
				{
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
					options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				})
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}
	}
}