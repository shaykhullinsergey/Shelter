using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Shelter
{
	public static class AuthenticationExtensions
	{
		public static void AddShelterAuthentication(this IServiceCollection services, JwtSection section)
		{
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
						ValidAudience = section.Issuer,
						ValidIssuer = section.Issuer,
						IssuerSigningKey = section.GetSecurityKey(),
						ClockSkew = TimeSpan.Zero
					};
				});
		}
	}
}