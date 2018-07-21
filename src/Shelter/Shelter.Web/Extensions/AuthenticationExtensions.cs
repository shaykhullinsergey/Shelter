using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Shelter
{
	public static class AuthenticationExtensions
	{
		public static void AddShelterAuthentication(this IServiceCollection services)
		{
			var configuration = services.BuildServiceProvider()
				.CreateScope()
				.ServiceProvider
				.GetRequiredService<JwtConfiguration>();
			
			services.AddAuthentication(options =>
				{
					options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
					options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				})
				.AddJwtBearer(options =>
				{
					options.SaveToken = true;
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidAudience = configuration.JwtIssuer,
						ValidIssuer = configuration.JwtIssuer,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.JwtKey))
					};
				});
		}
	}
}