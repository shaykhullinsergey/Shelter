using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
			services.AddTypedConfiguration(Configuration);
			services.AddGates();
			
			services.AddResponseCaching();
			services.AddResponseCompression();
			
			services.AddLocalization<EnglishAuthLocalization>();

			services.AddSingleton<AuthValidation>();
			
			services.AddDbContextPool<AuthContext>(options =>
				options.UseInMemoryDatabase(nameof(AuthContext)));
			
			services.AddShelterIdentity();
			services.AddShelterAuthentication();
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