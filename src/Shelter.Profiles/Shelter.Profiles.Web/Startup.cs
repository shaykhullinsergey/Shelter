using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shelter.Profiles.Web;

namespace Shelter
{
	public class Startup
	{
		private IConfiguration Configuration { get; }
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		
		public void ConfigureServices(IServiceCollection services)
		{
			var config = services.AddShelterConfiguration<ProfilesConfiguration>(Configuration);
			services.AddShelterGateways();
			
			services.AddResponseCaching();
			services.AddResponseCompression();
			
			services.AddShelterLocalization<EnglishProfilesLocalization>();
			services.AddShelterValidation<ProfilesValidation>();
			
			services.AddShelterInMemoryDbContextPool<ProfilesContext>();
			
			services.AddShelterAuthentication(config.Service.Jwt);
			services.AddShelterMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.UseResponseCaching();
			app.UseResponseCompression();
			
			app.UseErrorHandling();
			
			app.UseAuthentication();
			app.UseMvcWithDefaultRoute();
		}
	}
}