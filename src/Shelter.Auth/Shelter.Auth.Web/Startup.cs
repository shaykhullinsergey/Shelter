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
			var config = services.AddShelterConfiguration<AuthConfiguration>(Configuration);
			services.AddShelterGateways();
			
			services.AddResponseCaching();
			services.AddResponseCompression();
			
			services.AddShelterLocalization<EnglishAuthLocalization>();
			services.AddShelterValidation<AuthValidation>();
			
			services.AddDbContextPool<AuthContext>(options =>
				options.UseInMemoryDatabase(nameof(AuthContext)));
			
			services.AddAuthIdentity();

			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<ITokenGenerator, JwtTokenGenerator>();
			
			services.AddShelterAuthentication(config.Auth);
			services.AddShelterMvc();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			app.ConfigureInMemoryDatabase();
			
			app.UseResponseCaching();
			app.UseResponseCompression();
			
			app.UseErrorHandling();
			
			app.UseAuthentication();
			app.UseMvcWithDefaultRoute();
		}
	}
}